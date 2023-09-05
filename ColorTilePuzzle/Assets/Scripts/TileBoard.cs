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
;
    }

    private void CreateTile()
    {
        Tile.Tilecolor tilecolor = Tile.Tilecolor.Red;
        for (int i = 1; i <= tileCount; i++)
        {
            if (i % 2 != 0)
            {
                tilecolor = (Tile.Tilecolor)Random.Range(1, System.Enum.GetValues(typeof(Tile.Tilecolor)).Length);
            }
            TileCell cell = _grid.GetRandomEmptyCell();
            cell.empty = false;
            cell.tile.image.enabled = true;
            cell.tile.SetColor(tilecolor);
        }
    }
}
