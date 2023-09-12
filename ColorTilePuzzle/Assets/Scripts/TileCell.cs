using UnityEngine;
using UnityEngine.UI;

public class TileCell : MonoBehaviour
{
    public Vector2Int coordinates { get; set; }
    public Tile tile;
    public bool empty;

    public StateMachine PlayerStateMachine => playerStateMachine;
    private StateMachine playerStateMachine;

    private void Awake()
    {
        tile = GetComponentInChildren<Tile>();
        playerStateMachine = new StateMachine(this);
    }

    private void Start()
    {
        playerStateMachine.Initialize(playerStateMachine.HiddenState);
    }

    private void Update()
    {
        playerStateMachine.Update();
    }

    public void StateReset()
    {
        playerStateMachine.Initialize(playerStateMachine.HiddenState);
    }
}
