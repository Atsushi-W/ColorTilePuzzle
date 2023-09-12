using System;

[Serializable]
public class StateMachine
{
    public IState CurrentState { get; private set; }

    public DisplayState DisplayState;
    public HiddenState HiddenState;
    public DeleteState DeleteState;

    public StateMachine(TileCell cell)
    {
        this.DisplayState = new DisplayState(cell);
        this.HiddenState = new HiddenState(cell);
        this.DeleteState = new DeleteState(cell);
    }

    public void Initialize(IState startState)
    {
        CurrentState = startState;
        startState.Enter();
    }

    public void Transition(IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
}