﻿using UnityEngine;

namespace _2248 {
	public class TileGenerator {
		private TileGeneratorConfig _config;

		public TileGenerator(TileGeneratorConfig config) {
			_config = config;
		}

		public Tile CreateRandom() {
			int index = Random.Range(1, _config.MaxInitPow + 1);

			int value = (int)Mathf.Pow(_config.Base, index);

			return Create(value);
		}

		public Tile Create(int value) {
			value = Validate(value);

			Color color = GetColor(value);
			TileData data = new TileData(color, value);

			Tile tile = _config.TilePrefab.Clone();
			tile.Init(data);

			return tile;
		}

		private Color GetColor(int value) {
			int index = Mathf.FloorToInt(Mathf.Log(value, _config.Base) - 1);
			return _config.Colors[index % _config.Colors.Length];
		}

		private int Validate(int value) {
			int log = Mathf.FloorToInt(Mathf.Log(value, _config.Base));
			int pow = Mathf.FloorToInt(Mathf.Pow(_config.Base, log));
			return pow;
		}
	}
}
