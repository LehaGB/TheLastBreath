using UnityEngine;

public class Food : InteractiveObject
{
    [Tooltip("Каллории банана")]
    [Header("Каллории банана")]
    [SerializeField] private float calories = 10;

    private PlayerHealth playerHealth;


    private void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    public override void Action()
    {
        playerHealth.AddCalories(calories);
        Destroy(gameObject);
    }
}
