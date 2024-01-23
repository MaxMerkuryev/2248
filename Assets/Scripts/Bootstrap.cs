using UnityEngine;

namespace _2248 {
	public class Bootstrap : MonoBehaviour {
		[SerializeField] private GridConfig _gridConfig;
		[SerializeField] private Canvas _canvas;

		private void Awake() {
			new Grid(_canvas.transform, _gridConfig);
		}
	}
}
