using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClickTrigger : MonoBehaviour, IPointerClickHandler
{
    private TileCell cell;

    private void Start()
    {
        cell = GetComponent<TileCell>();
    }

    // クリックされたときに呼び出されるメソッド
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(cell.coordinates);
    }
}