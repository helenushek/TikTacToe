using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private float duration;
    private void Start()
    {
        Invoke("LoadNextScene", duration);
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
