using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClickTrigger : MonoBehaviour, IPointerClickHandler
{
    private TileCell cell;

    private void Start()
    {
        cell = GetComponent<TileCell>();
    }

    // �N���b�N���ꂽ�Ƃ��ɌĂяo����郁�\�b�h
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(cell.coordinates);
    }
}