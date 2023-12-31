using UnityEngine;

public class HiddenState : IState
{
    private TileCell cell;

    public HiddenState(TileCell cell)
    {
        this.cell = cell;
    }

    public void Enter()
    {
        // セルの非表示
        cell.empty = true;
        cell.tile.image.enabled = false;
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
