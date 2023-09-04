using UnityEngine;

public class TileBoard : MonoBehaviour
{
    [Range(0, 288)]
    public int tileCount = 144;
    private TileGrid _grid;

    private void Awake()
    {
        _grid = GetComponentInChildren<TileGrid>();
        _grid.afterSetUp += CreateTile;
    }

    private void Start()
    {
        
    }

    private void CreateTile()
    {
        for (int i = 0; i < tileCount; i++)
        {
            TileCell cell = _grid.GetRandomEmptyCell();
            cell.tile.image.enabled = true;
        }
    }
}
