using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : InteractiveObject
{
    [Header("Имя сцены")]
    [SerializeField] private string sceneName;
    public override void Action()
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
}
