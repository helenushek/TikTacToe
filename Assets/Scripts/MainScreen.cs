using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown SizeMode;

    [SerializeField] private TMP_Dropdown GameMode2;
    
    //делаем так, чтобы переменные по размеру поля и типу игры были видны в инспекторе 
    
    public void ToPlay()
    {
        int value = GameMode2.value;
        if (value == 0)
        {
            Settings.Gamestate = GameState.PvP;
        }

        if (value == 1)
        {
            Settings.Gamestate = GameState.PvR;
        }
        if (value == 2)
        {
            Settings.Gamestate = GameState.RvR;
        }
        
        
        Settings.size = SizeMode.value;
        if (SizeMode.value == 0)
        {
            Settings.size = 3;
            SceneManager.LoadScene("3x3");
        }
        if (SizeMode.value == 1)
        {
            Settings.size = 4;
            SceneManager.LoadScene("4x4");
        }
        if (SizeMode.value == 2)
        {
            Settings.size = 5;
            SceneManager.LoadScene("5x5");
        }
    }
}
