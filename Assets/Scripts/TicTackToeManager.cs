using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TicTackToeManager : MonoBehaviour
{
    [SerializeField] private List<Button> cell;
    [FormerlySerializedAs("Cross")] [SerializeField] private GameObject cross;
    [FormerlySerializedAs("Circle")] [SerializeField] private GameObject circle;
    

    private void Start()
    {
        if (Settings.Size == 3)
        {
            if (Settings.Gamestate == GameState.PvP)
            {
                PvP3X3 component = gameObject.AddComponent<PvP3X3>();
               component.Init(cell, cross, circle);
               
            }

            if (Settings.Gamestate == GameState.PvR)
            {
                PvE3X3 component = gameObject.AddComponent<PvE3X3>();
                component.Init(cell, cross, circle);
            }
            if (Settings.Gamestate == GameState.RvR)
            {
                EvE3X3 component = gameObject.AddComponent<EvE3X3>();
                component.Init(cell, cross, circle);
            }
            
        }

        if (Settings.Size == 4)
        {
            if (Settings.Gamestate == GameState.PvP)
            {
                PvP4X4 component = gameObject.AddComponent<PvP4X4>();
                component.Init(cell, cross, circle);
            }

            if (Settings.Gamestate == GameState.PvR)
            {
                PvE4X4 component = gameObject.AddComponent < PvE4X4 > ();
                component.Init(cell, cross, circle);
            }
            if (Settings.Gamestate == GameState.RvR)
            {
                EvE4X4 component = gameObject.AddComponent<EvE4X4>();
                component.Init(cell, cross, circle);
            }
        }


        if (Settings.Size == 5)
        {
            if (Settings.Gamestate == GameState.PvP)
            {
                PvP5X5 component = gameObject.AddComponent<PvP5X5>();
                component.Init(cell, cross, circle);
            }

            if (Settings.Gamestate == GameState.PvR)
            {
                PvE5X5 component = gameObject.AddComponent<PvE5X5>();
                component.Init(cell, cross, circle);
            }
            
            if (Settings.Gamestate == GameState.RvR)
            {
                Eve5X5 component = gameObject.AddComponent<Eve5X5>();
                component.Init(cell, cross, circle);
            }
        }
    }

    
}
