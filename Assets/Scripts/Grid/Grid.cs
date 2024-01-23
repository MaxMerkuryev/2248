using System.Collections.Generic;
using UnityEngine;

namespace _2248 {
	public class Grid {
		public static Grid Instance;
		
		private Transform _container;
		private GridConfig _config;
		private TileGenerator _generator;
		private Tile[,] _tiles;
		private List<(int x, int y)> _emptyCells;

		private Vector2 _containerPosition => _container.transform.position;
		private Vector2 _origin => new Vector3(_config.GridSize.x, _config.GridSize.y) * _config.TileSize / 2f;

		public Grid(Transform container, GridConfig config, TileGenerator generator) {
			Instance = this;

			_config = config;
			_container = container;
			_generator = generator;
			_tiles = new Tile[_config.GridSize.x, _config.GridSize.y];

			FillGrid();
		}

		public void Destroy(List<Tile> tiles) {
			for (int i = 0; i < tiles.Count; i++) {
				(int x, int y) coord = tiles[i].Coord;

				if (IsValidCoord(coord)) {
					Object.Destroy(_tiles[coord.x, coord.y]);
					_emptyCells.Add(coord);
				} 
			}
		}

		public void FillEmptyCells() {
			for (int i = 0; i < _emptyCells.Count; i++) {
				(int x, int y) coord = _emptyCells[i];
				Tile tile = _generator.CreateRandom();
				AddTile(coord, tile);
			}

			_emptyCells.Clear();
		}

		private void AddTile((int x, int y) coord, Tile tile) {
			Vector2 tilePosition = GetPositionFromCoord(coord.x, coord.y);
			tile.Init(coord, _container, tilePosition);
			_tiles[coord.x, coord.y] = tile;
		}

		private Vector2 GetPositionFromCoord(int x, int y) {
			return _containerPosition 
				+ Vector2.one * _config.TileSize / 2f 
				- _origin + new Vector2(x, y) * _config.TileSize;
		}

		private bool IsValidCoord((int x, int y) coord) {
			return coord.x >= 0 && coord.x < _tiles.GetLength(0)
				&& coord.y >= 0 && coord.y < _tiles.GetLength(1);
		}

		private void FillGrid() {
			for (int x = 0; x < _config.GridSize.x; x++) {
				for (int y = 0; y < _config.GridSize.y; y++) {
					Tile tile = _generator.CreateRandom();
					AddTile((x,y), tile);
				}
			}
		}
	}
}
