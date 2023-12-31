using System;
using UnityEngine;

public class TileGrid : MonoBehaviour
{
    public static TileGrid Instance;

    public TileRow[] rows { get; private set; }
    public TileCell[] cells { get; private set; }

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        rows = GetComponentsInChildren<TileRow>();
        cells = GetComponentsInChildren<TileCell>();
    }

    private void Start()
    {
        for (int y = 0; y < rows.Length; y++)
        {
            for (int x = 0; x < rows[y].cells.Length; x++)
            {
                rows[y].cells[x].coordinates = new Vector2Int(x, y);
            }
        }
    }

    public void ResetTile()
    {
        for (int y = 0; y < rows.Length; y++)
        {
            for (int x = 0; x < rows[y].cells.Length; x++)
            {
                rows[y].cells[x].StateReset();
            }
        }
    }

    public TileCell GetRandomEmptyCell()
    {
        int index = UnityEngine.Random.Range(0, cells.Length);
        int startingIndex = index;

        while (!cells[index].empty)
        {
            index++;

            if (index >= cells.Length)
            {
                index = 0;
            }

            if (index == startingIndex)
            {
                return null;
            }

        }

        return cells[index];
    }

    /* coordinatesの座標軸について
     * x:左から右にかけて0,1,2...23
     * y:上から下にかけて0,1,2...11
     */
    public TileCell UpTileCheck(Vector2Int coordinates)
    {
        TileCell cell;
        int x = coordinates.x;
        int y = coordinates.y - 1;

        if (y < 0)
        {
            return null;
        }

        for(int i = y; y >= 0; y--)
        {
            cell = rows[y].cells[x];
            if (!cell.empty)
            {
                return rows[y].cells[x];
            }
        }

        return null;
    }

    public TileCell DownTileCheck(Vector2Int coordinates)
    {
        TileCell cell;
        int x = coordinates.x;
        int y = coordinates.y + 1;

        if (y > 11)
        {
            return null;
        }

        for (int i = y; y <= 11; y++)
        {
            cell = rows[y].cells[x];
            if (!cell.empty)
            {
                return rows[y].cells[x];
            }
        }

        return null;
    }

    public TileCell RightTileCheck(Vector2Int coordinates)
    {
        TileCell cell;
        int x = coordinates.x + 1;
        int y = coordinates.y;

        if (x > 23)
        {
            return null;
        }

        for (int i = x; x <= 23; x++)
        {
            cell = rows[y].cells[x];
            if (!cell.empty)
            {
                return rows[y].cells[x];
            }
        }

        return null;
    }

    public TileCell LeftTileCheck(Vector2Int coordinates)
    {
        TileCell cell;
        int x = coordinates.x - 1;
        int y = coordinates.y;

        if (x < 0)
        {
            return null;
        }

        for (int i = x; x >= 0; x--)
        {
            cell = rows[y].cells[x];
            if (!cell.empty)
            {
                return rows[y].cells[x];
            }
        }

        return null;
    }
}
