using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MainScreen : MonoBehaviour
{

    [FormerlySerializedAs("SizeMode")] [SerializeField] private TMP_Dropdown sizeMode;

    [FormerlySerializedAs("GameMode2")] [SerializeField] private TMP_Dropdown gameMode2;
    
    private void Start()
    {
        FindObjectOfType<Music>().ContinueMusic();
    }

    public void ToPlay()
    {
        int value = gameMode2.value;
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
        
        
        Settings.Size = sizeMode.value;
        if (sizeMode.value == 0)
        {
            Settings.Size = 3;
            SceneManager.LoadScene("3x3");
        }
        if (sizeMode.value == 1)
        {
            Settings.Size = 4;
            SceneManager.LoadScene("4x4");
        }
        if (sizeMode.value == 2)
        {
            Settings.Size = 5;
            SceneManager.LoadScene("5x5");
        }
    }
}
