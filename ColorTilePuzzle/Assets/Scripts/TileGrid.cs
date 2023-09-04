using System;
using UnityEngine;

public class TileGrid : MonoBehaviour
{
    public TileRow[] rows { get; private set; }
    public TileCell[] cells { get; private set; }
    public Action afterSetUp;

    private void Awake()
    {
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
        if (afterSetUp != null)
        {
            afterSetUp.Invoke();
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
}
