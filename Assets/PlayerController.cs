using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    static int MAX_SNAKE_SIZE = 50;
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] GameObject snakeBodyPrefab;

    Vector2 direction;

    List<SnakeBody> snakeBodies = new();

    public UnityEvent OnDirectionChanged = new();

    private void Start()
    {
        OnDirectionChanged.AddListener(UpdateBodies);
    }
    private void Update()
    {
        var previousDirection = direction;
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }
        if (previousDirection + direction == Vector2.zero)
        {
            direction = previousDirection;
        }
        rb.linearVelocity = direction * moveSpeed;
        if (previousDirection != direction)
        {
            OnDirectionChanged.Invoke();
        }
    }

  public void AddNewBody()
    {
        var offset = -direction * 0.5f;
        var body = Instantiate(snakeBodyPrefab, offset, Quaternion.identity).GetComponent<SnakeBody>();
        var bodyDelay = snakeBodies.Count + 1;
        body.Initialize(bodyDelay);
        snakeBodies.Add(body);
    }
    void UpdateBodies()
    {
        StartCoroutine(UpdateSnakeBodies());
    }
    IEnumerator UpdateSnakeBodies()
    {
        for (int i = 0; i < snakeBodies.Count; i++)
        {
            yield return new WaitForSeconds(0.5f);
            var body = snakeBodies[i];
            body.rb.linearVelocity = direction * moveSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Apple"))
        {
            ScoreDisplay.Instance.OnAppleEaten();
            GameManager.Instance.OnAppleEaten(collision);
            AddNewBody();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameManager.Instance.OnWallCollision();
        }
    }
}
