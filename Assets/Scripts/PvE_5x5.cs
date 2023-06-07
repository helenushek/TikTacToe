using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PvE_5x5 : PvE_Base
{
    private List<List<int>> winInternal = new List<List<int>>()
    {
        new List<int>() { 0, 1, 2, 3, 4},
        new List<int>() { 5, 6, 7, 8, 9 },
        new List<int>() { 10, 11, 12, 13, 14 },
        new List<int>() { 15, 16, 17, 18, 19 },
        new List<int>() { 20, 21, 22, 23, 24 },


        new List<int>() { 0, 5, 10, 15, 20 },
        new List<int>() { 1, 6, 11, 16, 21 },
        new List<int>() { 2, 7, 12, 17, 22 },
        new List<int>() { 3, 8, 13, 18, 23 },
        new List<int>() { 4, 9, 14, 19, 24 },

        new List<int>() { 0, 6, 12, 18, 24 },
        new List<int>() { 4, 8, 12, 16, 20 },
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
        for (int i = 0; i < 25; i += 5)
        {
            v = GetFreeIndex(new List<Turn>() { VseHody[0 + i], VseHody[1 + i], VseHody[2 + i], VseHody[3 + i], VseHody[4 + i] }, t);
            if (v != -1)
                return v + i;
        }

        for (int i = 0; i < 5; i++)
        {
            v = GetFreeIndex(new List<Turn>() { VseHody[0 + i], VseHody[5 + i], VseHody[10 + i], VseHody[15 + i], VseHody[20 + i] }, t);
            if (v != -1)
                return v * 5 + i;
        }

        v = GetFreeIndex(new List<Turn>() { VseHody[0], VseHody[6], VseHody[12], VseHody[18], VseHody[24] }, t);
        if (v != -1)
            return v * 6;
        
        v = GetFreeIndex(new List<Turn>() { VseHody[4], VseHody[8], VseHody[12], VseHody[16], VseHody[20] }, t);
        if (v != -1)
            return (v + 1) * 4;
        
        return -1;
    }
}