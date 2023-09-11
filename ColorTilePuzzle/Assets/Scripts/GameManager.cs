using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Action<int> OnScoreUpdate;
    public Action OnScoreReset;

    [SerializeField]
    private float _timer = 120.0f;
    [SerializeField]
    private Slider TimerSlider;
    [SerializeField]
    private int _decreasetime = 10;
    [SerializeField]
    private int _combo = 1;
    [SerializeField]
    private GameObject _gameOverObj;
    [SerializeField]
    private TextMeshProUGUI _resultScore;

    private float _maxTime;
    private int _defaultcombo;
    private bool _timerFlag;
    private int _score;

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
        _timerFlag = false;
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
        _score += 1 * _combo;

        if (OnScoreUpdate != null)
        {
            OnScoreUpdate.Invoke(_score);
        }
    }

    public void ComboCount()
    {
        _combo++;
    }

    public void DecreaseTime()
    {
        _timer -= _decreasetime;
        TimerSlider.value = _timer / _maxTime;
        _combo = _defaultcombo;
    }

    public void GameReset()
    {
        _timer = _maxTime;
        _timerFlag = true;
        _combo = 1;
        _score = 0;

        if (OnScoreReset != null)
        {
            OnScoreReset.Invoke();
        }

        AudioManager.Instance.PlaySE(AudioManager.SEName.Play);
    }

    private void TimerCount()
    {
        _timer -= Time.deltaTime;

        TimerSlider.value = _timer / _maxTime;

        if (_timer <= 0)
        {
            _timerFlag = false;
            _resultScore.text = _score.ToString();
            _gameOverObj.SetActive(true);
            AudioManager.Instance.PlaySE(AudioManager.SEName.Result);
        }
    }
}
