using UnityEngine;

namespace _2248 {
	[CreateAssetMenu(menuName = "2248/Tile Generator Config")]
	public class TileGeneratorConfig : ScriptableObject {
		[field: SerializeField] public Tile TilePrefab { get; private set; }
		[field: SerializeField] public int Base { get; private set; }
		[field: SerializeField] public int MaxInitPow { get; private set; }
		[field: SerializeField] public Color[] Colors { get; private set; }
	}
}
