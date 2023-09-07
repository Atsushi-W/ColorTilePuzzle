using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Slider TimerSlider;
    public TextMeshProUGUI ScoreText;

    [SerializeField]
    private float _timer = 120.0f;
    [SerializeField]
    private int _decreasetime = 10;
    [SerializeField]
    private int _combo = 1;

    private float _maxTime;
    private int _defaultcombo;
    private bool _timerFlag;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _maxTime = _timer;
        _defaultcombo = _combo;
        _timerFlag = true;
    }

    private void Update()
    {
        if (_timerFlag)
        {
            TimerCount();
        }
    }

    public void ScoreCount()
    {
        int score = int.Parse(ScoreText.text);
        score += 1 * _combo;
        ScoreText.text = score.ToString();
    }

    public void ComboCount()
    {
        _combo++;
    }

    public void DecreaseTime()
    {
        _timer -= _decreasetime;
        TimerSlider.value = _timer / _maxTime;
        // ComboReset
        _combo = _defaultcombo;
    }

    private void TimerCount()
    {
        _timer -= Time.deltaTime;

        TimerSlider.value = _timer / _maxTime;

        if (_timer <= 0)
        {
            _timerFlag = false;
        }
    }
}
