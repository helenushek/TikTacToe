using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTackToeManager : MonoBehaviour
{
    [SerializeField] private List<Button> cell;
    [SerializeField] private GameObject Cross;
    [SerializeField] private GameObject Circle;
    [SerializeField] private Transform canvas;

    private void Start()
    {
        if (Settings.size == 3)
        {
            if (Settings.Gamestate == GameState.PvP)
            {
                PvP_3x3 component = gameObject.AddComponent<PvP_3x3>();
               component.Init(cell, Cross, Circle, canvas);
               
            }

            if (Settings.Gamestate == GameState.PvR)
            {
                PvE_3x3 component = gameObject.AddComponent<PvE_3x3>();
                component.Init(cell, Cross, Circle, canvas);
            }
        }

        if (Settings.size == 4)
        {
            if (Settings.Gamestate == GameState.PvP)
            {
                PvP_4x4 component = gameObject.AddComponent<PvP_4x4>();
                component.Init(cell, Cross, Circle, canvas);
            }

            if (Settings.Gamestate == GameState.PvR)
            {
                PvE_4x4 component = gameObject.AddComponent < PvE_4x4 > ();
                component.Init(cell, Cross, Circle, canvas);
            }
        }


        if (Settings.size == 5)
        {
            if (Settings.Gamestate == GameState.PvP)
            {
                PvP_5x5 component = gameObject.AddComponent<PvP_5x5>();
                component.Init(cell, Cross, Circle, canvas);
            }

            if (Settings.Gamestate == GameState.PvR)
            {
                PvE_5x5 component = gameObject.AddComponent<PvE_5x5>();
                component.Init(cell, Cross, Circle, canvas);
            }
        }
    }

    
}
