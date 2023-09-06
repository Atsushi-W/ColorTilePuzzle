using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float timer = 120.0f;
    public int decreasetime = 10;

    public Slider timerSlider;
    public TextMeshProUGUI scoreText;

    private float maxTime;
    private bool timerFlag;

    private void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        maxTime = timer;
        timerFlag = true;
    }

    private void Update()
    {
        if (timerFlag)
        {
            TimerCount();
        }
    }

    public void ScoreCount()
    {
        int score = int.Parse(scoreText.text);
        score++;
        scoreText.text = score.ToString();
    }

    public void DecreaseTime()
    {
        timer -= decreasetime;
        timerSlider.value = timer / maxTime;
    }

    private void TimerCount()
    {
        timer -= Time.deltaTime;

        timerSlider.value = timer / maxTime;

        if (timer <= 0)
        {
            timerFlag = false;
        }
    }
}
