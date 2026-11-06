using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance { get; private set; }

    [SerializeField] TMP_Text scoreTracker;

    int currentScore = 0;
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
            currentScore++;
            scoreTracker.text = currentScore.ToString();
        }
    }
}
