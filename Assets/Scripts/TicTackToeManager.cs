using System.Collections.Generic;
using PvP;
using PvR;
using RvR;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TicTackToeManager : MonoBehaviour
{
    [FormerlySerializedAs("cell")] [SerializeField] private List<Button> cells;
    [FormerlySerializedAs("Cross")] [SerializeField] private GameObject cross;
    [FormerlySerializedAs("Circle")] [SerializeField] private GameObject circle;
    

    private void Start()
    {
        FindObjectOfType<Music>().StopMusic();
        if (Settings.Size == 3)
        {
            if (Settings.Gamestate == GameState.PvP)
            {
                PvP_3x3 component = gameObject.AddComponent<PvP_3x3>();
                component.Init(cells, cross, circle);
            }

            if (Settings.Gamestate == GameState.PvR)
            {
                PvR_3x3 component = gameObject.AddComponent<PvR_3x3>();
                component.Init(cells, cross, circle);
            }
            if (Settings.Gamestate == GameState.RvR)
            {
                RvR_3x3 component = gameObject.AddComponent<RvR_3x3>();
                component.Init(cells, cross, circle);
            }
            
        }

        if (Settings.Size == 4)
        {
            if (Settings.Gamestate == GameState.PvP)
            {
                PvP_4x4 component = gameObject.AddComponent<PvP_4x4>();
                component.Init(cells, cross, circle);
            }

            if (Settings.Gamestate == GameState.PvR)
            {
                PvR_4x4 component = gameObject.AddComponent < PvR_4x4 > ();
                component.Init(cells, cross, circle);
            }
            if (Settings.Gamestate == GameState.RvR)
            {
                RvR_4x4 component = gameObject.AddComponent<RvR_4x4>();
                component.Init(cells, cross, circle);
            }
        }


        if (Settings.Size == 5)
        {
            if (Settings.Gamestate == GameState.PvP)
            {
                PvP_5x5 component = gameObject.AddComponent<PvP_5x5>();
                component.Init(cells, cross, circle);
            }

            if (Settings.Gamestate == GameState.PvR)
            {
                PvR_5x5 component = gameObject.AddComponent<PvR_5x5>();
                component.Init(cells, cross, circle);
            }
            
            if (Settings.Gamestate == GameState.RvR)
            {
                RvR_5x5 component = gameObject.AddComponent<RvR_5x5>();
                component.Init(cells, cross, circle);
            }
        }
    }

    
}
