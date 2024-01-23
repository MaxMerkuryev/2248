using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _2248 {
	public class SelectionHandler {
		private List<Tile> _tiles;
		private Grid _grid;

		public SelectionHandler(Grid grid) {
			_grid = grid;
			_tiles = new List<Tile>();
		}

		public void Update() {
			if (!Input.GetMouseButton(0)) {
				if (_tiles.Count > 0) Submit();
				return;
			}

			Vector2 mousePosition = Input.mousePosition;
			
			if (_grid.TryGetTile(mousePosition, out Tile tile)) {
				Register(tile);
			}
		}

		private void Register(Tile tile) {
			if (IsPrevious(tile)) {
				RemoveCurrent();
				return;
			}

			if (IsRegistered(tile)) {
				return;
			}

			if (IsValid(tile)) {
				Add(tile);
			}
		}

		private void Submit() {
			if(_tiles.Count <= 1) {
				foreach (Tile tile in _tiles) {
					tile.Deselect();
				}

				_tiles.Clear();
				return;
			}

			(int x, int y) coord = GetLastTile().Coord;
			int value = _tiles.Sum(x => x.Value);

			_grid.Clear(_tiles.Where(x => x != GetLastTile()).ToList());
			_grid.Create(coord, value);

			_tiles.Clear();
		}

		private void Add(Tile tile) {
			tile.Select();
			_tiles.Add(tile);
		}

		private void RemoveCurrent() {
			Tile tile = GetLastTile();
			tile.Deselect();

			_tiles.Remove(tile);
		}

		private bool IsRegistered(Tile tile) {
			return _tiles.Contains(tile);
		}

		private bool IsPrevious(Tile tile) {
			if (_tiles.Count <= 1) return false;
			return _tiles[_tiles.Count - 2].Coord == tile.Coord;
		}

		private bool IsValid(Tile tile) {
			if (ListIsEmpty()) return true;

			return IsValidCoord(tile.Coord) 
				&& IsEqualOrGreaterThenMax(tile.Value) 
				&& FitsRange(tile.Value);
		}

		private bool IsValidCoord((int x, int y) coord) {
			Tile lastTile = GetLastTile();

			int x = Mathf.Abs(coord.x - lastTile.Coord.x);
			int y = Mathf.Abs(coord.y - lastTile.Coord.y) ;

			return  x <= 1 && y <= 1;
		}

		private bool IsEqualOrGreaterThenMax(int value) => value >= _tiles.Max(x => x.Value);
		private bool FitsRange(int value) => value <= _tiles.Sum(x => x.Value);
		private bool ListIsEmpty() => _tiles.Count == 0;

		private Tile GetLastTile() {
			return _tiles[^1];
		}
	}
}
