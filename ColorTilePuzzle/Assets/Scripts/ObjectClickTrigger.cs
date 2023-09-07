using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClickTrigger : MonoBehaviour, IPointerClickHandler
{
    private TileCell cell;
    private bool clickflag = true;

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
        TileCell upTile = TileGrid.instance.UpTileCheck(cell.coordinates);
        TileCell downTile = TileGrid.instance.DownTileCheck(cell.coordinates);
        TileCell rightTile = TileGrid.instance.RightTileCheck(cell.coordinates);
        TileCell leftTile = TileGrid.instance.LeftTileCheck(cell.coordinates);

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
        bool tileflag = false;

        if (upTileColor == downTileColor && upTileColor != Tile.Tilecolor.None)
        {
            if (!upTile.empty)
            {
                upTile.tile.image.enabled = false;
                upTile.empty = true;
                // TODO;スコアを追加
                GameManager.Instance.ScoreCount();
                tileflag = true;
            }
            if (!downTile.empty)
            {
                downTile.tile.image.enabled = false;
                downTile.empty = true;
                // TODO;スコアを追加
                GameManager.Instance.ScoreCount();
                tileflag = true;
            }
        }
        if (upTileColor == rightTileColor && upTileColor != Tile.Tilecolor.None)
        {
            if (!upTile.empty)
            {
                upTile.tile.image.enabled = false;
                upTile.empty = true;
                // TODO;スコアを追加
                GameManager.Instance.ScoreCount();
                tileflag = true;
            }
            if (!rightTile.empty)
            {
                rightTile.tile.image.enabled = false;
                rightTile.empty = true;
                // TODO;スコアを追加
                GameManager.Instance.ScoreCount();
                tileflag = true;
            }
        }
        if (upTileColor == leftTileColor && upTileColor != Tile.Tilecolor.None)
        {
            if (!upTile.empty)
            {
                upTile.tile.image.enabled = false;
                upTile.empty = true;
                // TODO;スコアを追加
                GameManager.Instance.ScoreCount();
                tileflag = true;
            }
            if (!leftTile.empty)
            {
                leftTile.tile.image.enabled = false;
                leftTile.empty = true;
                // TODO;スコアを追加
                GameManager.Instance.ScoreCount();
                tileflag = true;
            }
        }
        if (downTileColor == rightTileColor && downTileColor != Tile.Tilecolor.None)
        {
            if (!downTile.empty)
            {
                downTile.tile.image.enabled = false;
                downTile.empty = true;
                // TODO;スコアを追加
                GameManager.Instance.ScoreCount();
                tileflag = true;
            }
            if (!rightTile.empty)
            {
                rightTile.tile.image.enabled = false;
                rightTile.empty = true;
                // TODO;スコアを追加
                GameManager.Instance.ScoreCount();
                tileflag = true;
            }
        }
        if (downTileColor == leftTileColor && downTileColor != Tile.Tilecolor.None)
        {
            if (!downTile.empty)
            {
                downTile.tile.image.enabled = false;
                downTile.empty = true;
                // TODO;スコアを追加
                GameManager.Instance.ScoreCount();
                tileflag = true;
            }
            if (!leftTile.empty)
            {
                leftTile.tile.image.enabled = false;
                leftTile.empty = true;
                // TODO;スコアを追加
                GameManager.Instance.ScoreCount();
                tileflag = true;
            }
        }
        if (rightTileColor == leftTileColor && rightTileColor != Tile.Tilecolor.None)
        {
            if (!rightTile.empty)
            {
                rightTile.tile.image.enabled = false;
                rightTile.empty = true;
                // TODO;スコアを追加
                GameManager.Instance.ScoreCount();
                tileflag = true;
            }
            if (!leftTile.empty)
            {
                leftTile.tile.image.enabled = false;
                leftTile.empty = true;
                // TODO;スコアを追加
                GameManager.Instance.ScoreCount();
                tileflag = true;
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
}