using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    private int _score;
    private int _maxScore;
    [SerializeField] private Text outputCurrentScore;
    [SerializeField] private Text outputMaxScore;

    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("ScoreManager");
                    _instance = container.AddComponent<ScoreManager>();
                    _instance.InitializeManager();
                }
            }

            return _instance;
        }
    }

    public void AddScore(int count)
    {
        _score += count;
        MaxScore();
        Render();
    }

    public void FinishGame()
    {
        MaxScore();
        _score = 0;
        Render();
    }

    private void MaxScore()
    {
        if (_score > _maxScore)
        {
            _maxScore = _score;
        }
    }

    private void InitializeManager()
    {
        _score = 0;
        Render();
    }

    private void Render()
    {
        if (outputCurrentScore != null)
        {
            outputCurrentScore.text = _score.ToString();
        }

        if (outputMaxScore != null)
        {
            outputMaxScore.text = _maxScore.ToString();
        }
    }
}