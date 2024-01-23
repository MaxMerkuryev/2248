using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _2248 {
	public class Tile : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler {
		[SerializeField] private TextMeshProUGUI _valueText;
		[SerializeField] private SpriteRenderer _renderer;

		public (int x, int y) Coord { get; private set; }

		public void Init(int x, int y) {
			Coord = new(x, y);
		}

		public void OnPointerDown(PointerEventData eventData) {
			Grid.Instance.Delete(Coord.x, Coord.y);
		}

		public void OnPointerUp(PointerEventData eventData) {
		}

		public void OnPointerEnter(PointerEventData eventData) {
		}

		public void OnPointerExit(PointerEventData eventData) {
		}
	}
}
