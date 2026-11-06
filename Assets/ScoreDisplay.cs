using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{

    public static ScoreDisplay Instance { get; private set; }

    [SerializeField] TMP_Text scoreTracker;

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

   public void OnAppleEaten()
    {
        if (scoreTracker != null)
        {
            GameManager.Instance.CurrentScore++;
            scoreTracker.text = GameManager.Instance.CurrentScore.ToString();
        }
    }
}
