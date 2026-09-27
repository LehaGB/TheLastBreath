using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("Жизнь игрока")]
    [Header("Уровень жизни игрока")]
    [SerializeField] private Slider healthSlider;

    [Space]

    [Tooltip("Желудок")]
    [Header("Уровень голодности")]
    [SerializeField] private Slider stomachSlider;

    [Space]

    [Tooltip("Уменьшение жизни")]
    [Header("На какое количество уменьшяется жизнь")]
    [SerializeField] private float minusInHealth = 0.05f;

    [Space]

    [Tooltip("Уменьшение желудка")]
    [Header("На какое количество уменьшяется желудок")]
    [SerializeField] private float minusInStomach = 0.05f;

    [Tooltip("GetComponent<Image>() желудка")]
    private Image stomachFillImage;

    [Tooltip("GetComponent<Image>() жизни")]
    private Image healthFillImage;

    [Tooltip("Текущий цвет слайдера желудка")]
    private Color mainStomachColor;

    [Tooltip("Текущий цвет слайдера жизни")]
    private Color mainHealthColor;

    private void Start()
    {
        stomachFillImage = stomachSlider.fillRect.GetComponent<Image>();
        mainStomachColor = stomachFillImage.color;

        healthFillImage = healthSlider.fillRect.GetComponent<Image>();
        mainHealthColor = healthFillImage.color;
    }


    private void Update()
    {
        StomachEmptying();
        ShorteningHealth();
    }

    //  Опустошение желудка.
    private void StomachEmptying()
    {
        if (stomachSlider.value != 0)
        {
            stomachSlider.value -= minusInStomach * Time.deltaTime;
            ChangeColorHungry(stomachSlider, stomachFillImage, mainStomachColor);
        }
    }


    //  Укорачивание жизни.
    private void ShorteningHealth()
    {
        if (stomachSlider.value == 0)
        {
            healthSlider.value -= minusInHealth * Time.deltaTime;
            ChangeColorHungry(healthSlider, healthFillImage, mainHealthColor);
        }
    }


    //  Меням цвут слайдера в зависимости от условия.
    private void ChangeColorHungry(Slider slider, Image image, Color mainColor)
    {
        if (slider.value > 50 && image.color != mainColor)
        {
            image.color = mainColor;
        }
        if (slider.value < 50 && slider.value > 15 && image.color != Color.yellow)
        {
            image.color = Color.yellow;
        }
        if (slider.value < 15 && image.color != Color.red)
        {
            image.color = Color.red;
        }   
    }

    public void AddCalories(float calories)
    {
        stomachSlider.value = Mathf.Min(stomachSlider.maxValue, stomachSlider.value + calories);
    }
}
