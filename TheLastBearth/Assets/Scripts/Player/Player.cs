using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Tooltip("Скорость игрока")]
    [Header("Скорость игрока")]
    [SerializeField] private float moveSpeed = 3f;

    [Space]

    [Tooltip("Загрузка позиции игрока при выходе из локации")]
    [Header("Загрузка позиции игрока при выходе из локации")]
    [SerializeField] private bool realoadPosition = false;

    [Space]

    [Header("Аниматор игрока")]
    [SerializeField] private Animator animator;

    private Rigidbody2D rb;
    private Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        int isPositionAvalaible = PlayerPrefs.GetInt(ConstRestartPlayerPostion.RESTART_POSITION_AVALAIBLE);

        if (realoadPosition && isPositionAvalaible == 1)
        {
            gameObject.transform.position = LoadRestartPosition();
        }
    }

    void Update()
    {
        rb.linearVelocity = movement * moveSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Interactive"))
        {
            collision.gameObject.GetComponent<InteractiveObject>().Action();
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isMoving", true);

        if (context.canceled)
        {
            animator.SetBool("isMoving", false);
            animator.SetFloat("LastX", movement.x);
            animator.SetFloat("LastY", movement.y);
        }
        movement = context.ReadValue<Vector2>();

        animator.SetFloat("InputX", movement.x);
        animator.SetFloat("InputY", movement.y);
    }

    private Vector2 LoadRestartPosition()
    {
        return new Vector2(PlayerPrefs.GetFloat(ConstRestartPlayerPostion.X_RESTART_POSITION),
            PlayerPrefs.GetFloat(ConstRestartPlayerPostion.Y_RESTART_POSITION));
    }
}
