using UnityEngine;

public class Food : InteractiveObject
{
    [Tooltip("Каллории банана")]
    [Header("Каллории фрукта")]
    [SerializeField] private float calories = 10;

    [Tooltip("Скорость роста фрукта")]
    [Header("Скорость роста фрукта")]
    [SerializeField] private float fruitsGrowSpeed = 0.003f;

    [Tooltip("Оригинальный размер фрукта")]
    private Vector3 originScaleFruits;

    [Tooltip("Ссылка на скрипт, жизь игрока")]
    private PlayerHealth playerHealth;


    private void Start()
    {
        originScaleFruits = transform.localScale;
        transform.localScale = Vector3.zero;
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }


    private void Update()
    {
        GrowFruits();
    }

    public override void Action()
    {
        playerHealth.AddCalories(calories);
        Destroy(gameObject);
    }


    private void GrowFruits()
    {
        if(originScaleFruits.x > transform.localScale.x)
        {
            Vector3 newScale = transform.localScale;
            newScale.x += fruitsGrowSpeed * Time.deltaTime;
            newScale.y += fruitsGrowSpeed * Time.deltaTime;
            transform.localScale = newScale;
        }
    }
}
