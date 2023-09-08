using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public enum Tilecolor
    {
        None = 0,
        Red,
        Green,
        Blue,
        Yellow,
        Magenta,
    }

    public TileCell cell { get; private set; }
    public Tilecolor tilecolor;
    public Image image;

    private ParticleSystem[] particles;

    private void Awake()
    {
        image = GetComponent<Image>();
        particles = GetComponentsInChildren<ParticleSystem>();
    }

    public void ParticlePlay()
    {
        if (particles == null)
        {
            return;
        }

        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].Play();
        }
    }

    public void SetColor(Tilecolor tilecolor)
    {
        this.tilecolor = tilecolor;
        switch(this.tilecolor)
        {
            case Tilecolor.Red:
                image.color = Color.red;
                break;
            case Tilecolor.Green:
                image.color = Color.green;
                break;
            case Tilecolor.Blue:
                image.color = Color.blue;
                break;
            case Tilecolor.Yellow:
                image.color = Color.yellow;
                break;
            case Tilecolor.Magenta:
                image.color = Color.magenta;
                break;
            default:
                break;
        }
    }

}
