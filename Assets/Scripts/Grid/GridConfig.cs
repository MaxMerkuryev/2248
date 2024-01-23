using UnityEngine;

namespace _2248 {
	[CreateAssetMenu(menuName = "2248/Grid Config")]
	public class GridConfig : ScriptableObject {
		[field: SerializeField] public Tile TilePrefab { get; private set; }
		[field: SerializeField] public int TilesCountX { get; private set; }
		[field: SerializeField] public int TilesCountY { get; private set; }
		[field: SerializeField] public float TileSize { get; private set; }
	}
}
