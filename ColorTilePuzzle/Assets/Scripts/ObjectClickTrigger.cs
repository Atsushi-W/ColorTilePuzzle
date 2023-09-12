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

    // �N���b�N���ꂽ�Ƃ��ɌĂяo����郁�\�b�h
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
        // �㉺���E�̃^�C���m�F
        TileCell upTile = TileGrid.Instance.UpTileCheck(cell.coordinates);
        TileCell downTile = TileGrid.Instance.DownTileCheck(cell.coordinates);
        TileCell rightTile = TileGrid.Instance.RightTileCheck(cell.coordinates);
        TileCell leftTile = TileGrid.Instance.LeftTileCheck(cell.coordinates);

        // �e�^�C���̐F�`�F�b�N
        Tile.Tilecolor upTileColor = upTile != null ? upTile.tile.tilecolor : Tile.Tilecolor.None;
        Tile.Tilecolor downTileColor = downTile != null ? downTile.tile.tilecolor : Tile.Tilecolor.None;
        Tile.Tilecolor rightTileColor = rightTile != null ? rightTile.tile.tilecolor : Tile.Tilecolor.None;
        Tile.Tilecolor leftTileColor = leftTile != null ? leftTile.tile.tilecolor : Tile.Tilecolor.None;

        Debug.Log(upTileColor + ", " + downTileColor + ", " + rightTileColor + ", " + leftTileColor);

        // �g�ݍ��킹�͈ȉ���5��
        // �E�^�C���̐F�̈�v�Ȃ�
        // �E�����F�̃^�C����2����
        // �E�����F�̃^�C����3����
        // �E�����F�̃^�C����4����
        // �E�����F�̃^�C����2������(��:�ԐF�^�C��2�ƐF�^�C��2��)

        // �g�ݍ��킹�m�F�p�t���O
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