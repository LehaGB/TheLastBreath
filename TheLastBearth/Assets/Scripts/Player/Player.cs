using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Tooltip("Скорость игрока")]
    [Header("Скорость игрока")]
    [SerializeField] private float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocity = movement * moveSpeed;
    }


    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
