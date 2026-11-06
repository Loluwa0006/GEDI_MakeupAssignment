using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public Rigidbody2D rb;
    int delayTicks = 0;

    public void Initialize(int delayTicks)
    {
        this.delayTicks = delayTicks;
    }
}
