using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] GameObject applePrefab;

    public void SpawnNewApple(Vector2 position)
    {
        if (applePrefab != null)
        {
            Instantiate(applePrefab, position, Quaternion.identity);
        }
    }
}
