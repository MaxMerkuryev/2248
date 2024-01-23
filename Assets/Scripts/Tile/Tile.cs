using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _2248 {
	public class Tile : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler {
		[SerializeField] private TextMeshProUGUI _value;
		[SerializeField] private Image _image;

		public (int x, int y) Coord { get; private set; }

		public Tile Clone() {
			return Instantiate(this);
		}

		public void Init(TileData data) {
			_value.text = data.Value.ToString();
			_image.color = data.Color;
		}

		public void Init((int x, int y) coord, Transform parent, Vector2 position) {
			Coord = coord;
			transform.position = position;
			transform.SetParent(parent);
		}

		public void OnPointerDown(PointerEventData eventData) {
			// register this
		}

		public void OnPointerUp(PointerEventData eventData) {
			// ???
		}

		public void OnPointerEnter(PointerEventData eventData) {
			// register this ?
		}
	}
}
