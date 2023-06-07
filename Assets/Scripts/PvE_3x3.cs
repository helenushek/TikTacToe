using System.Collections.Generic;
using UnityEngine;

public class PvE_3x3 : PvE_Base
{
    private List<List<int>> winInternal = new List<List<int>>()
    {
        new List<int>() { 0, 1, 2 },
        new List<int>() { 3, 4, 5 },
        new List<int>() { 6, 7, 8 },

        new List<int>() { 0, 3, 6 },
        new List<int>() { 1, 4, 7 },
        new List<int>() { 2, 5, 8 },

        new List<int>() { 0, 4, 8 },
        new List<int>() { 2, 4, 6 }
    };

    protected override void InitInternal()
    {
        win = winInternal;
    }
    protected override void PcTurn()
    {
        GameObject newFigure = Instantiate(Nolik);
        int index;
        if (PervyHod == true)
        {
            if (VseHody[4] == Turn.None)
            {
                index = 4;
            }
            else
            {
                index = 2;
            }

            VseHody[index] = Turn.Enemy;
        }
        else
        {
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
        }

        Transform newFugireTransform = newFigure.GetComponent<Transform>();
        newFugireTransform.position = knopki[index].transform.position;
        newFugireTransform.parent = Canvas;
        VseHody[index] = Turn.Enemy;
        WhoisOn = FirstPlayer.Cross;
        PervyHod = false;
        ChekWin();
    }
    private int GetIndex(Turn t)
    {
        int v;
        for (int i = 0; i < 9; i += 3)
        {
            v = GetFreeIndex(new List<Turn>() { VseHody[0 + i], VseHody[1 + i], VseHody[2 + i] }, t);
            if (v != -1) 
                return v + i;
        }

        for (int i = 0; i < 3; i++)
        {
            v = GetFreeIndex(new List<Turn>() { VseHody[0 + i], VseHody[3 + i], VseHody[6 + i] }, t);
            if (v != -1) 
                return v * 3 + i;
            
        }
        
        v = GetFreeIndex(new List<Turn>() { VseHody[0], VseHody[4], VseHody[8] }, t);
        if (v != -1)
            return v * 4;

        v = GetFreeIndex(new List<Turn>() { VseHody[2], VseHody[4], VseHody[6] }, t);
        if (v != -1)
            return (v + 1) * 2;

        return -1;
    }
    
}