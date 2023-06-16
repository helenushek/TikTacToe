using UnityEngine;
using UnityEngine.SceneManagement;

public class AllButton : MonoBehaviour
{
  public void Restart()
  {
    SceneManager.LoadScene("MainScreen");
  }
}
