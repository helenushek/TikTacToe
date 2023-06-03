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
        for (int i = 0; i < 9; i += 3)
        {
            if (VseHody[0 + i] == t && VseHody[1 + i] == t && VseHody[2 + i] == Turn.None)
                return 2 + i;
            if (VseHody[0 + i] == t && VseHody[1 + i] == Turn.None && VseHody[2 + i] == t)
                return 1 + i;
            if (VseHody[0 + i] == Turn.None && VseHody[1 + i] == t && VseHody[2 + i] == t)
                return 0 + i;
        }

        for (int i = 0; i < 3; i++)
        {
            if (VseHody[0 + i] == t && VseHody[3 + i] == t && VseHody[6 + i] == Turn.None)
                return 6 + i;
            if (VseHody[0 + i] == t && VseHody[3 + i] == Turn.None && VseHody[6 + i] == t)
                return 3 + i;
            if (VseHody[0 + i] == Turn.None && VseHody[3 + i] == t && VseHody[6 + i] == t)
                return 0 + i;
        }

        if (VseHody[0] == t && VseHody[4] == t && VseHody[8] == Turn.None)
            return 8;
        if (VseHody[0] == t && VseHody[4] == Turn.None && VseHody[8] == t)
            return 4;
        if (VseHody[0] == Turn.None && VseHody[4] == t && VseHody[8] == t)
            return 0;

        if (VseHody[2] == t && VseHody[4] == t && VseHody[6] == Turn.None)
            return 6;
        if (VseHody[2] == t && VseHody[4] == Turn.None && VseHody[6] == t)
            return 4;
        if (VseHody[2] == Turn.None && VseHody[4] == t && VseHody[6] == t)
            return 2;

        return -1;
    }
    
}