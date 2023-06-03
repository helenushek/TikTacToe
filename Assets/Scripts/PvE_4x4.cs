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
        for (int i = 0; i < 16; i += 4)
        {
            if (VseHody[0 + i] == t && VseHody[1 + i] == t && VseHody[2 + i] == t && VseHody[3 + i] == Turn.None)
                return 3 + i;
            if (VseHody[0 + i] == t && VseHody[1 + i] == t && VseHody[2 + i] == Turn.None && VseHody[3 + i] == t)
                return 2 + i;
            if (VseHody[0 + i] == t && VseHody[1 + i] == Turn.None && VseHody[2 + i] == t && VseHody[3 + i] == t)
                return 1 + i;
            if (VseHody[0 + i] == Turn.None && VseHody[1 + i] == t && VseHody[2 + i] == t && VseHody[3 + i] == t)
                return 0 + i;
        }

        for (int i = 0; i < 4; i++)
        {
            if (VseHody[0 + i] == t && VseHody[4 + i] == t && VseHody[8 + i] == t && VseHody[12 + i] == Turn.None)
                return 12 + i;
            if (VseHody[0 + i] == t && VseHody[4 + i] == t && VseHody[8 + i] ==  Turn.None && VseHody[12 + i] == t)
                return 8 + i;
            if (VseHody[0 + i] == t && VseHody[4 + i] == Turn.None && VseHody[8 + i] == t && VseHody[12 + i] == t)
                return 4 + i;
            if (VseHody[0 + i] == Turn.None && VseHody[4 + i] == t && VseHody[8 + i] == t && VseHody[12 + i] == t)
                return 0 + i;
        }

        if (VseHody[0] == t && VseHody[5] == t && VseHody[10] == t && VseHody[15] == Turn.None)
            return 15;
        if (VseHody[0] == t && VseHody[5] == t && VseHody[10] == Turn.None && VseHody[15] == t)
            return 10;
        if (VseHody[0] == t && VseHody[5] == Turn.None && VseHody[10] == t && VseHody[15] == t)
            return 5;
        if (VseHody[0] == Turn.None && VseHody[5] == t && VseHody[10] == t && VseHody[15] == t)
            return 0;

        if (VseHody[3] == t && VseHody[6] == t && VseHody[9] == t && VseHody[12] == Turn.None) 
            return 12;
        if (VseHody[3] == t && VseHody[6] == t && VseHody[9] == Turn.None && VseHody[12] == t)
            return 9;
        if (VseHody[3] == t && VseHody[6] == Turn.None && VseHody[9] == t && VseHody[12] == t)
            return 6;
        if (VseHody[3] == Turn.None && VseHody[6] == t && VseHody[9] == t && VseHody[12] == t)
            return 3;
        return -1;
    }

    
}