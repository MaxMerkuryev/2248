using DG.Tweening;
using TMPro;
using UnityEngine;
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
			AnimateScale(1.1f);
		}

		public void Deselect() {
			AnimateScale(1);
		}

		public void PlayAppearAnimation(float delay) {
			transform.localScale = Vector3.zero;
			DOTween.Sequence().Insert(delay, AnimateScale(1));
		}

		private Tween AnimateScale(float scale) {
			transform.DOComplete();
			return transform.DOScale(scale, 0.3f).SetEase(Ease.OutBack);
		}
	}
}
