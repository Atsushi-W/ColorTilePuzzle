using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnScoreUpdate += UpdateScore;
        GameManager.Instance.OnScoreReset += ResetScore;
    }

    private void UpdateScore(int score)
    {
        _scoreText.text = score.ToString();
    }

    private void ResetScore()
    {
        _scoreText.text = "0";
    }
}
