using UnityEngine;

namespace _2248 {
	[CreateAssetMenu(menuName = "2248/Grid Config")]
	public class GridConfig : ScriptableObject {
		[field: SerializeField] public Vector2Int GridSize { get; private set; }
		[field: SerializeField] public float TileSize { get; private set; }
	}
}
