using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public enum Tilecolor
    {
        Red,
        Green,
        Blue,
        Orange,
        Pink,
    }

    public TileCell cell { get; private set; }
    public Tilecolor tilecolor;
    public Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetColor(Tilecolor tilecolor)
    {
        this.tilecolor = tilecolor;
    }

}
