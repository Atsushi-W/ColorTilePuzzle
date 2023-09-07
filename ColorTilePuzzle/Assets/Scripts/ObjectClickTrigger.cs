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
        TileCell upTile = TileGrid.instance.UpTileCheck(cell.coordinates);
        TileCell downTile = TileGrid.instance.DownTileCheck(cell.coordinates);
        TileCell rightTile = TileGrid.instance.RightTileCheck(cell.coordinates);
        TileCell leftTile = TileGrid.instance.LeftTileCheck(cell.coordinates);

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
        bool tileflag = false;

        if (upTileColor == downTileColor && upTileColor != Tile.Tilecolor.None)
        {
            if (!upTile.empty)
            {
                upTile.tile.image.enabled = false;
                upTile.empty = true;
                // TODO;�X�R�A��ǉ�
                GameManager.Instance.ScoreCount();
                tileflag = true;
            }
            if (!downTile.empty)
            {
                downTile.tile.image.enabled = false;
                downTile.empty = true;
                // TODO;�X�R�A��ǉ�
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
                // TODO;�X�R�A��ǉ�
                GameManager.Instance.ScoreCount();
                tileflag = true;
            }
            if (!rightTile.empty)
            {
                rightTile.tile.image.enabled = false;
                rightTile.empty = true;
                // TODO;�X�R�A��ǉ�
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
                // TODO;�X�R�A��ǉ�
                GameManager.Instance.ScoreCount();
                tileflag = true;
            }
            if (!leftTile.empty)
            {
                leftTile.tile.image.enabled = false;
                leftTile.empty = true;
                // TODO;�X�R�A��ǉ�
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
                // TODO;�X�R�A��ǉ�
                GameManager.Instance.ScoreCount();
                tileflag = true;
            }
            if (!rightTile.empty)
            {
                rightTile.tile.image.enabled = false;
                rightTile.empty = true;
                // TODO;�X�R�A��ǉ�
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
                // TODO;�X�R�A��ǉ�
                GameManager.Instance.ScoreCount();
                tileflag = true;
            }
            if (!leftTile.empty)
            {
                leftTile.tile.image.enabled = false;
                leftTile.empty = true;
                // TODO;�X�R�A��ǉ�
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
                // TODO;�X�R�A��ǉ�
                GameManager.Instance.ScoreCount();
                tileflag = true;
            }
            if (!leftTile.empty)
            {
                leftTile.tile.image.enabled = false;
                leftTile.empty = true;
                // TODO;�X�R�A��ǉ�
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