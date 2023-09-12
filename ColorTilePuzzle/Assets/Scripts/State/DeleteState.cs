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
        // セルの非表示
        cell.empty = true;
        cell.tile.image.enabled = false;
        // セルを消去時のパーティクル再生
        cell.tile.ParticlePlay();
        // スコア加算
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
