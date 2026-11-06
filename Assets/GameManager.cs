using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] GameObject gameOverScreen;
    [SerializeField] AppleSpawner appleSpawner;

    [SerializeField] Transform appleSpawnLeft;
    [SerializeField] Transform appleSpawnDown;
    [SerializeField] Transform appleSpawnRight;
    [SerializeField] Transform appleSpawnUp;

    public int CurrentScore { get; set; } = 0;

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

    public void GetNewApple()
    {
        var spawnPositionX = Random.Range(appleSpawnLeft.position.x, appleSpawnRight.position.x);
        var spawnPositionY = Random.Range(appleSpawnDown.position.y, appleSpawnUp.position.y);
        appleSpawner.SpawnNewApple(new Vector2(spawnPositionX, spawnPositionY));
    }

    public void OnAppleEaten(Collider2D collision)
    {
        Destroy(collision.gameObject);
        GetNewApple();
    }
}
