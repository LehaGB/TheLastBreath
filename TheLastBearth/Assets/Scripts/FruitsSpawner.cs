using UnityEngine;

public class FruitsSpawner : MonoBehaviour
{
    [Header("Ссылка на префаб фруктов")]
    [SerializeField] private GameObject fruitsPrefab;

    [Header("Спаун позиция фруктов по Х")]
    [SerializeField] private float fruitsPosOffsetX = 0.3f;

    [Header("Спаун позиция фруктов по Y")]
    [SerializeField] private float fruitsPosOffsetY = 0.3f;

    [Header("Время выращивания фрутка")]
    [SerializeField] private float fruitsCreateTime = 5f;

    private GameObject fruits;
    private bool isFruitsCreated = false;


    private void Start()
    {
        
    }


    private void Update()
    {
        if(fruits == null && !isFruitsCreated)
        {
            Invoke("SpawnFruits", fruitsCreateTime);
            isFruitsCreated = true;
        }
    }

    private void SpawnFruits()
    {
        fruits = Instantiate(fruitsPrefab);
        Vector3 pos = gameObject.transform.position;

        pos.x += fruitsPosOffsetX;
        pos.y += fruitsPosOffsetY;

        fruits.transform.position = pos;

        isFruitsCreated = false;
    }
}
