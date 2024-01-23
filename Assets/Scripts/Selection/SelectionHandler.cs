using System.Collections.Generic;

namespace _2248 {
	public class SelectionHandler {
		private List<TileData> _tiles;
		private Grid _grid;
		private int _sum;

		public SelectionHandler(Grid grid) {
			_grid = grid;
		}

		public void TryRegister(TileData tileData) {
			if (IsPrevious(tileData)) Remove(tileData);
			else if(IsValid(tileData)) Add(tileData);
		}

		public void Submit() {
			// tell grid to destroy tiles from stack
			// tell grid to create tile with final value at final coords
		}

		private void Add(TileData tileData) {
			_tiles.Add(tileData);
			_sum += tileData.Value;
		}

		private void Remove(TileData tileData) {
			_tiles.Remove(tileData);
			_sum -= tileData.Value;
		}

		private bool IsPrevious(TileData tileData) {
			if (_tiles.Count <= 1) return false;
			return _tiles[_tiles.Count - 2].Value == tileData.Value;
		}

		private bool IsValid(TileData tileData) {
			return tileData.Value <= _sum;
		}
	}
}
