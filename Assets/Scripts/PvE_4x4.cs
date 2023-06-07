using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PvE_4x4 : PvE_Base
{
    private List<List<int>> winInternal = new List<List<int>>()
    {
        new List<int>() { 0, 1, 2, 3 },
        new List<int>() { 4, 5, 6, 7 },
        new List<int>() { 8, 9, 10, 11 },
        new List<int>() { 12, 13, 14, 15 },


        new List<int>() { 0, 4, 8, 12 },
        new List<int>() { 1, 5, 9, 13 },
        new List<int>() { 2, 6, 10, 14 },
        new List<int>() { 3, 7, 11, 15 },

        new List<int>() { 0, 5, 10, 15 },
        new List<int>() { 3, 6, 9, 12 },
    };

    protected override void InitInternal()
    {
        win = winInternal;
    }
    
    protected override void PcTurn()
    {
        GameObject newFigure = Instantiate(Nolik);
        int index;

        int value = GetIndex(Turn.Enemy); // крестики (мы - PC)
        if (value == -1)
        {
            value = GetIndex(Turn.Player); // нолики (игрок)
            if (value == -1)
            {
                value = GetRandomIndex();
                index = value;
            }
            else
            {
                index = value;
            }
        }
        else
        {
            index = value;
        }

        Transform newFugireTransform = newFigure.GetComponent<Transform>();
        Button button = knopki[index];
        newFugireTransform.position = button.transform.position;
        newFugireTransform.parent = button.transform;
        VseHody[index] = Turn.Enemy;
        WhoisOn = FirstPlayer.Cross;
        PervyHod = false;
        ChekWin();
    }

    private int GetIndex(Turn t)
    { 
        int v;
        for (int i = 0; i < 16; i += 4)
        {
            v = GetFreeIndex(new List<Turn>() { VseHody[0 + i], VseHody[1 + i], VseHody[2 + i], VseHody[3 + i] }, t);
            if (v != -1)
                return v + i;
        }

        for (int i = 0; i < 4; i++)
        {
            v = GetFreeIndex(new List<Turn>() { VseHody[0 + i], VseHody[4 + i], VseHody[8 + i], VseHody[12 + i] }, t);
            if (v != -1)
                return v * 4 + i;
        }
        
        v = GetFreeIndex(new List<Turn>() { VseHody[0], VseHody[5], VseHody[10], VseHody[15] }, t);
        if (v != -1)
            return v * 5;
        
        v = GetFreeIndex(new List<Turn>() { VseHody[3], VseHody[6], VseHody[9], VseHody[12] }, t);
        if (v != -1)
            return (v + 1) * 3;
        
        return -1;
    } 

    
}