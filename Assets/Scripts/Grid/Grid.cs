using System.Collections.Generic;
using UnityEngine;

namespace _2248 {
	public class Grid {		
		private Transform _container;
		private GridConfig _config;
		private TileGenerator _generator;
		private Tile[,] _tiles;
		private List<(int x, int y)> _emptyCells;

		private Vector2 _containerPosition => _container.transform.position;
		private Vector2 _origin => new Vector3(_config.GridSize.x, _config.GridSize.y) * _config.TileSize / 2f;

		public Grid(Transform container, GridConfig config, TileGenerator generator) {
			_config = config;
			_container = container;
			_generator = generator;
			_tiles = new Tile[_config.GridSize.x, _config.GridSize.y];

			FillGrid();
		}

		public void Clear(List<Tile> tiles) {
			for (int i = 0; i < tiles.Count; i++) {
				(int x, int y) coord = tiles[i].Coord;

				if (IsValidCoord(coord)) {
					Object.Destroy(_tiles[coord.x, coord.y].gameObject);
					_emptyCells.Add(coord);
				} 
			}
		}

		public void FillEmptyCells() {
			for (int i = 0; i < _emptyCells.Count; i++) {
				AddTile(_emptyCells[i], _generator.CreateRandom());
			}

			_emptyCells.Clear();
		}

		public void Create((int x, int y) coord, int value) {
			if (IsValidCoord(coord)) {
				Object.Destroy(_tiles[coord.x, coord.y].gameObject);				
				AddTile(coord, _generator.Create(value));
			}
		}

		public bool TryGetTile(Vector2 position, out Tile tile) {
			(int x, int y) coord = GetCoordFromPosition(position);
			if (IsValidCoord(coord)) {
				tile = _tiles[coord.x, coord.y];
				return true;
			}

			tile = null;
			return false;
		}

		private (int x, int y) GetCoordFromPosition(Vector2 position) {
			Vector2 coord = (position - _containerPosition - Vector2.one * _config.TileSize / 2f + _origin) / _config.TileSize;
			return (Mathf.RoundToInt(coord.x), Mathf.RoundToInt(coord.y));
		}

		private Vector2 GetPositionFromCoord(int x, int y) {
			return _containerPosition + Vector2.one * _config.TileSize / 2f - _origin + new Vector2(x, y) * _config.TileSize;
		}

		private bool IsValidCoord((int x, int y) coord) {
			return coord.x >= 0 && coord.x < _tiles.GetLength(0)
				&& coord.y >= 0 && coord.y < _tiles.GetLength(1);
		}

		private void FillGrid() {
			for (int x = 0; x < _config.GridSize.x; x++) {
				for (int y = 0; y < _config.GridSize.y; y++) {
					AddTile((x,y), _generator.CreateRandom());
				}
			}
		}

		private void AddTile((int x, int y) coord, Tile tile) {
			Vector2 tilePosition = GetPositionFromCoord(coord.x, coord.y);
			tile.Init(coord, _container, tilePosition);
			_tiles[coord.x, coord.y] = tile;
		}
	}
}
