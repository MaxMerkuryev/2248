using System.Collections.Generic;
using UnityEngine;

namespace _2248 {
	public class SelectionHandler {
		private List<Tile> _tiles;
		private Grid _grid;
		private int _sum;

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
			Debug.LogError("register");

			if (IsPrevious(tile)) {
				RemoveCurrent();
				return;
			}
			
			Debug.LogError("not previous");

			if (IsRegistered(tile)) {
				return;
			}
			
			Debug.LogError("not registered");

			if (IsValid(tile)) {
				Debug.LogError("valid");
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

			Tile lastTile = _tiles[^1];
			(int x, int y) lastTileCoord = lastTile.Coord;
			int lastTileValue = lastTile.Value;

			_grid.Clear(_tiles);
			_grid.Create(lastTileCoord, lastTileValue);

			_tiles.Clear();
		}

		private void Add(Tile tile) {
			tile.Select();
			_tiles.Add(tile);
			_sum += tile.Value;
		}

		private void RemoveCurrent() {
			Tile tile = _tiles[^1];
			tile.Deselect();

			_tiles.Remove(tile);
			_sum -= tile.Value;
		}

		private bool IsRegistered(Tile tile) {
			return _tiles.Contains(tile);
		}

		private bool IsPrevious(Tile tile) {
			if (_tiles.Count <= 1) return false;
			return _tiles[_tiles.Count - 2].Coord == tile.Coord;
		}

		private bool IsValid(Tile tile) {
			return _tiles.Count == 0 || tile.Value <= _sum;
		}
	}
}
