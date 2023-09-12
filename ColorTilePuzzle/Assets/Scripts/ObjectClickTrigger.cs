using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClickTrigger : MonoBehaviour, IPointerClickHandler
{
    private TileCell cell;
    private bool clickflag = true;
    private bool tileflag = false;

    private void Start()
    {
        cell = GetComponent<TileCell>();
    }

    // クリックされたときに呼び出されるメソッド
    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickflag)
        {
            if (cell.empty)
            {
                clickflag = false;
                TileCheck();
            }
        }
    }

    private void TileCheck()
    {
        // 上下左右のタイル確認
        TileCell upTile = TileGrid.Instance.UpTileCheck(cell.coordinates);
        TileCell downTile = TileGrid.Instance.DownTileCheck(cell.coordinates);
        TileCell rightTile = TileGrid.Instance.RightTileCheck(cell.coordinates);
        TileCell leftTile = TileGrid.Instance.LeftTileCheck(cell.coordinates);

        // 各タイルの色チェック
        Tile.Tilecolor upTileColor = upTile != null ? upTile.tile.tilecolor : Tile.Tilecolor.None;
        Tile.Tilecolor downTileColor = downTile != null ? downTile.tile.tilecolor : Tile.Tilecolor.None;
        Tile.Tilecolor rightTileColor = rightTile != null ? rightTile.tile.tilecolor : Tile.Tilecolor.None;
        Tile.Tilecolor leftTileColor = leftTile != null ? leftTile.tile.tilecolor : Tile.Tilecolor.None;

        Debug.Log(upTileColor + ", " + downTileColor + ", " + rightTileColor + ", " + leftTileColor);

        // 組み合わせは以下の5つ
        // ・タイルの色の一致なし
        // ・同じ色のタイルが2つある
        // ・同じ色のタイルが3つある
        // ・同じ色のタイルが4つある
        // ・同じ色のタイルが2つずつある(例:赤色タイル2つと青色タイル2つ等)

        // 組み合わせ確認用フラグ
        tileflag = false;

        if (upTileColor == downTileColor && upTileColor != Tile.Tilecolor.None)
        {
            if (!upTile.empty)
            {
                FlagUpdate(upTile);
            }
            if (!downTile.empty)
            {
                FlagUpdate(downTile);
            }
        }
        if (upTileColor == rightTileColor && upTileColor != Tile.Tilecolor.None)
        {
            if (!upTile.empty)
            {
                FlagUpdate(upTile);
            }
            if (!rightTile.empty)
            {
                FlagUpdate(rightTile);
            }
        }
        if (upTileColor == leftTileColor && upTileColor != Tile.Tilecolor.None)
        {
            if (!upTile.empty)
            {
                FlagUpdate(upTile);
            }
            if (!leftTile.empty)
            {
                FlagUpdate(leftTile);
            }
        }
        if (downTileColor == rightTileColor && downTileColor != Tile.Tilecolor.None)
        {
            if (!downTile.empty)
            {
                FlagUpdate(downTile);
            }
            if (!rightTile.empty)
            {
                FlagUpdate(rightTile);
            }
        }
        if (downTileColor == leftTileColor && downTileColor != Tile.Tilecolor.None)
        {
            if (!downTile.empty)
            {
                FlagUpdate(downTile);
            }
            if (!leftTile.empty)
            {
                FlagUpdate(leftTile);
            }
        }
        if (rightTileColor == leftTileColor && rightTileColor != Tile.Tilecolor.None)
        {
            if (!rightTile.empty)
            {
                FlagUpdate(rightTile);
            }
            if (!leftTile.empty)
            {
                FlagUpdate(leftTile);
            }
        }

        if (!tileflag)
        {
            GameManager.Instance.DecreaseTime();
            AudioManager.Instance.PlaySE(AudioManager.SEName.Miss);
        }
        else
        {
            GameManager.Instance.ComboCount();
            AudioManager.Instance.PlaySE(AudioManager.SEName.TileDelete);
        }

        clickflag = true;
    }

    private void FlagUpdate(TileCell cell)
    {
        cell.empty = true;
        tileflag = true;
    }
}