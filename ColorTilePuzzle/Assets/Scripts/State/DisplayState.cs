using UnityEngine;

public class DisplayState : IState
{
    private TileCell cell;

    public DisplayState(TileCell cell)
    {
        this.cell = cell;
    }

    public void Enter()
    {
        cell.empty = false;
        cell.tile.image.enabled = true;
    }

    public void Update()
    {
        if (!cell.empty)
        {
            return;
        }
        else
        {
            cell.PlayerStateMachine.Transition(cell.PlayerStateMachine.DeleteState);
        }
    }

    public void Exit()
    {

    }
}
