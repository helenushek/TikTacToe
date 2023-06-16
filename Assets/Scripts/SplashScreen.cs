using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private float duration;
    //делаем так, чтобы переменная duration была видна в инспекторе

    private void Start()
    {
        Invoke("LoadNextScene", duration);
    }
    //создаем метод Start, который управляет переходом на следующую сцену спустя указанное время

    private void LoadNextScene()
    {
        SceneManager.LoadScene("MainScreen");
    }
    
    //создаем метод LoadNextScene который загружает следующую сцену (главный экран)
}
