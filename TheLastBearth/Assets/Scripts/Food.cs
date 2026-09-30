using UnityEngine;

public class Food : FoodObject
{
    [Tooltip("Каллории фрукта")]
    [Header("Каллории фрукта")]
    [SerializeField] private float calories = 10;

    [Tooltip("Увеличение калорий по мере роста")]
    [Header("Увеличение калорий по мере роста")]
    [SerializeField] private float growCaloriesIncrease = 10;

    [Tooltip("Скорость роста фрукта")]
    [Header("Скорость роста фрукта")]
    [SerializeField] private float fruitsGrowSpeed = 0.003f;

    [Tooltip("Оригинальный размер фрукта")]
    private Vector3 originScaleFruits;


    private void Start()
    {
        originScaleFruits = transform.localScale;
        transform.localScale = Vector3.zero;
    }


    private void Update()
    {
        GrowFruits();
    }

    public override void Eat(PlayerHealth playerHealth)
    {
        playerHealth.AddCalories(calories);
        playerHealth.AddHealth(calories);
        Destroy(gameObject);
    }


    private void GrowFruits()
    {
        if(originScaleFruits.x > transform.localScale.x)
        {
            Vector3 newScale = transform.localScale;
            newScale.x += fruitsGrowSpeed * Time.deltaTime;
            newScale.y += fruitsGrowSpeed * Time.deltaTime;
            calories += (fruitsGrowSpeed * Time.deltaTime) * growCaloriesIncrease;
            Debug.Log("calories" + calories);
            transform.localScale = newScale;
        }
    }
}
