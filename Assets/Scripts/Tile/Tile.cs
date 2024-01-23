using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _2248 {
	public class Tile : MonoBehaviour {
		[SerializeField] private TextMeshProUGUI _value;
		[SerializeField] private Image _image;

		public (int x, int y) Coord { get; private set; }
		public int Value { get; private set; }

		public Tile Clone() {
			return Instantiate(this);
		}

		public void Init(TileData data) {
			_value.text = data.Value.ToString();
			_image.color = data.Color;

			Value = data.Value;
		}

		public void Init((int x, int y) coord, Transform parent, Vector2 position) {
			Coord = coord;
			transform.position = position;
			transform.SetParent(parent);
		}

		public void Select() {
			ScaleUp();
		}

		public void Deselect() {
			ScaleDown();
		}

		private void ScaleUp() {
			transform.localScale = Vector3.one * 1.1f;
		}

		private void ScaleDown() {
			transform.localScale = Vector3.one;
		}
	}
}
