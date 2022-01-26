using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    private int _score;
    public Text outputValue;

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
        render();
    }

    private void InitializeManager()
    {
        _score = 0;
        render();
    }

    private void render()
    {
        if (outputValue != null)
        {
            outputValue.text = _score.ToString();
        }
    }
}