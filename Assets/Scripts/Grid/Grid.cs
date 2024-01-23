using System.ComponentModel;
using UnityEngine;

namespace _2248 {
	public class Grid {
		public static Grid Instance;
		
		private Transform _container;
		private GridConfig _config;
		private Tile[,] _tiles;

		private Vector2 _containerPosition => _container.transform.position;

		public Grid(Transform container, GridConfig config) {
			Instance = this;

			_config = config;
			_container = container;

			int width = _config.TilesCountX;
			int height = _config.TilesCountY;

			Vector2 origin = new Vector3(width, height) * _config.TileSize / 2f;

			_tiles = new Tile[width, height];

			for (int x = 0; x < width; x++) {
				for (int y = 0; y < height; y++) {
					Vector2 position = _containerPosition + Vector2.one * _config.TileSize / 2f - origin + new Vector2(x, y) * _config.TileSize;

					_tiles[x, y] = Object.Instantiate(_config.TilePrefab, position, Quaternion.identity, _container);
					_tiles[x, y].Init(x, y);
				}
			}
		}

		public void Delete(int x, int y) {
			Object.Destroy(_tiles[x, y].gameObject);
		}
	}
}
