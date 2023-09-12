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
        // ƒZƒ‹‚Ì”ñ•\Ž¦
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
