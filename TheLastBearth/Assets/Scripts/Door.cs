using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : InteractiveObject
{
    [Header("Отдоляемся от двери")]
    [SerializeField] private float yPositionOffset = 2f;

    [Space]

    [Header("Имя сцены")]
    [SerializeField] private string sceneName;

    [Space]

    [Header("Сохранения позиции")]
    [SerializeField] private bool isSavePosition = false;

    public override void Action()
    {
        if (isSavePosition)
        {
            PlayerPrefs.SetInt(ConstRestartPlayerPostion.RESTART_POSITION_AVALAIBLE, 1);
            PlayerPrefs.SetFloat(ConstRestartPlayerPostion.X_RESTART_POSITION, gameObject.transform.position.x);
            PlayerPrefs.SetFloat(ConstRestartPlayerPostion.Y_RESTART_POSITION, gameObject.transform.position.y - yPositionOffset);
        }
       
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
}
