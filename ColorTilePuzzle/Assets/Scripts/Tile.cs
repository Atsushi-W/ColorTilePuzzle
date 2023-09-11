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
        Pink,
        Orange,
        Cyan,
        Gray,
        Brown,
        Violet,
    }

    public TileCell cell { get; private set; }
    public Tilecolor tilecolor;
    public Image image;

    private ParticleSystem[] particles;
    private ParticleSystemRenderer[] particleSystemRenderer;

    private void Awake()
    {
        image = GetComponent<Image>();
        particles = GetComponentsInChildren<ParticleSystem>();
        particleSystemRenderer = GetComponentsInChildren<ParticleSystemRenderer>();
    }

    public void ParticlePlay()
    {
        if (particles == null)
        {
            return;
        }

        for (int i = 0; i < particles.Length; i++)
        {
            particleSystemRenderer[i].material.color = image.color;
            particles[i].Play();
        }
    }

    public void SetColor(Tilecolor tilecolor)
    {
        Color color;
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
                ColorUtility.TryParseHtmlString("#FFD700", out color);
                image.color = color;
                break;
            case Tilecolor.Pink:
                ColorUtility.TryParseHtmlString("#FF69B4", out color);
                image.color = color;
                break;
            case Tilecolor.Orange:
                ColorUtility.TryParseHtmlString("#FF8C00", out color);
                image.color = color;
                break;
            case Tilecolor.Cyan:
                image.color = Color.cyan;
                break;
            case Tilecolor.Gray:
                image.color = Color.gray;
                break;
            case Tilecolor.Brown:
                ColorUtility.TryParseHtmlString("#8B4513", out color);
                image.color = color;
                break;
            case Tilecolor.Violet:
                ColorUtility.TryParseHtmlString("#8A2BE2", out color);
                image.color = color;
                break;
            default:
                break;
        }
    }

}
