using UnityEngine;
using UnityEngine.UI;

public class TileCell : MonoBehaviour
{
    public Vector2Int coordinates { get; set; }
    public Tile tile;

    public bool empty = true;

    private void Awake()
    {
        tile = GetComponentInChildren<Tile>();
    }
}
