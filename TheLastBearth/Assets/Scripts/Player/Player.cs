using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("Скорость игрока")]
    [Header("Скорость игрока")]
    [SerializeField] private float moveSpeed = 3f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(1f, 0f) * moveSpeed;
    }
}
