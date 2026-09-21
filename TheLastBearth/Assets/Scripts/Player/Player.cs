using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [Tooltip("Скорость игрока")]
    [Header("Скорость игрока")]
    [SerializeField] private float moveSpeed = 3f;
    [Space]
    [Header("Аниматор игрока")]
    [SerializeField] private Animator animator;
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
        animator.SetBool("isMoving", true);

        if (context.canceled)
        {
            animator.SetBool("isMoving", false);
            animator.SetFloat("lastX", movement.x);
            animator.SetFloat("lastY", movement.y);
        }
        movement = context.ReadValue<Vector2>();

        animator.SetFloat("InputX", movement.x);
        animator.SetFloat("InputY", movement.y);
    }
}
