using System.Collections.Generic;
using UnityEngine;

public class PvE3X3 : PvEBase
{
    private List<List<int>> _winInternal = new List<List<int>>()
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
        Win = _winInternal;
    }
    protected override void PcTurn()
    {
        GameObject newFigure = Instantiate(nolik);
        int index;
        if (pervyHod)
        {
            if (vseHody[4] == Turn.None)
            {
                index = 4;
            }
            else
            {
                index = 2;
            }

            vseHody[index] = Turn.Enemy;
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
        newFugireTransform.parent = knopki[index].transform;
        vseHody[index] = Turn.Enemy;
        whoisOn = WhoIsOn.Cross;
        pervyHod = false;
        ChekWin();
    }
    private int GetIndex(Turn t)
    {
        int v;
        for (int i = 0; i < 9; i += 3)
        {
            v = GetFreeIndex(new List<Turn>() { vseHody[0 + i], vseHody[1 + i], vseHody[2 + i] }, t);
            if (v != -1) 
                return v + i;
        }

        for (int i = 0; i < 3; i++)
        {
            v = GetFreeIndex(new List<Turn>() { vseHody[0 + i], vseHody[3 + i], vseHody[6 + i] }, t);
            if (v != -1) 
                return v * 3 + i;
            
        }
        
        v = GetFreeIndex(new List<Turn>() { vseHody[0], vseHody[4], vseHody[8] }, t);
        if (v != -1)
            return v * 4;

        v = GetFreeIndex(new List<Turn>() { vseHody[2], vseHody[4], vseHody[6] }, t);
        if (v != -1)
            return (v + 1) * 2;

        return -1;
    }
    
}