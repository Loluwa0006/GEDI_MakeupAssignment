using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] GameObject gameOverScreen;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        gameOverScreen.SetActive(false);
    }

    public void OnWallCollision()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
