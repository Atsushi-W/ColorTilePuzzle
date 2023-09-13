using System.Collections;
using UnityEngine;
using TMPro;

public class TileCell : MonoBehaviour
{
    public Vector2Int coordinates { get; set; }
    public Tile tile;
    public bool empty;

    public StateMachine PlayerStateMachine => playerStateMachine;
    private StateMachine playerStateMachine;

    private TextMeshProUGUI _combo;

    private void Awake()
    {
        tile = GetComponentInChildren<Tile>();
        playerStateMachine = new StateMachine(this);

        _combo = GetComponentInChildren<TextMeshProUGUI>();
        if (_combo != null)
            _combo.enabled = false;
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

    public void ComboSuccess()
    {
        StartCoroutine(StartComboDisplay(GameManager.Instance.ComboNum().ToString() + " Combo"));
    }

    public void ComboMiss()
    {
        StartCoroutine(StartComboDisplay("Miss!"));
    }

    private IEnumerator StartComboDisplay(string text)
    {
        _combo.text = text;
        _combo.enabled = true;

        yield return new WaitForSeconds(2);

        _combo.enabled = false;
    }
}
