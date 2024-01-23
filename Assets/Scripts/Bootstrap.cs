using UnityEngine;

namespace _2248 {
	public class Bootstrap : MonoBehaviour {
		[SerializeField] private TileGeneratorConfig _tileGeneratorConfig;
		[SerializeField] private GridConfig _gridConfig;
		[SerializeField] private Canvas _canvas;

		private void Awake() {
			TileGenerator generator = new TileGenerator(_tileGeneratorConfig);
			Grid grid = new Grid(_canvas.transform, _gridConfig, generator);
		}
	}
}
