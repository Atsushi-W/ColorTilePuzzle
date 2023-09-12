using UnityEngine;

public class DeleteState : IState
{
    private TileCell cell;

    public DeleteState(TileCell cell)
    {
        this.cell = cell;
    }

    public void Enter()
    {
        // �Z���̔�\��
        cell.empty = true;
        cell.tile.image.enabled = false;
        // �Z�����������̃p�[�e�B�N���Đ�
        cell.tile.ParticlePlay();
        // �X�R�A���Z
        GameManager.Instance.ScoreCount();
    }

    public void Update()
    {
        if (cell.empty)
        {
            return;
        }
        else
        {
            cell.PlayerStateMachine.Transition(cell.PlayerStateMachine.DisplayState);
        }
    }

    public void Exit()
    {

    }
}
