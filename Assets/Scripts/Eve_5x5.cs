using System.Collections.Generic;
using UnityEngine;

public class Eve5X5 : EvEBase
{
    protected override void InitInternal()
    {
        Win = _winInternal;
    }

    private List<List<int>> _winInternal = new List<List<int>>()
    {
        new List<int>() { 0, 1, 2, 3, 4 },
        new List<int>() { 5, 6, 7, 8, 9 },
        new List<int>() { 10, 11, 12, 13, 14 },
        new List<int>() { 15, 16, 17, 18, 19 },
        new List<int>() { 20, 21, 22, 23, 24 },

        new List<int>() { 0, 5, 10, 15, 20 },
        new List<int>() { 1, 6, 11, 16, 21 },
        new List<int>() { 2, 7, 12, 17, 22 },
        new List<int>() { 3, 8, 12, 18, 23 },
        new List<int>() { 4, 9, 14, 19, 24 },

        new List<int>() { 0, 6, 12, 18, 24 },
        new List<int>() { 4, 8, 12, 16, 20 },
    };

    protected override void PcTurn()
    {
        bool isNolik = whoisOn == WhoIsOn.Circle;

        GameObject newFigure;
        if (isNolik)
            newFigure = Instantiate(nolik);
        else
            newFigure = Instantiate(krestik);


        int index;
        int value;
        if (isNolik) value = GetIndex(Turn.Enemy);
        else value = GetIndex(Turn.Player);

        if (value == -1)
        {
            if (!isNolik) value = GetIndex(Turn.Enemy);
            else value = GetIndex(Turn.Player);

            if (value == -1) value = GetRandomIndex();
        }

        index = value;

        Transform newFugireTransform = newFigure.GetComponent<Transform>();
        newFugireTransform.position = Knopki[index].transform.position;
        newFugireTransform.parent = Knopki[index].transform;
        if (isNolik)
        {
            vseHody[index] = Turn.Enemy;
            whoisOn = WhoIsOn.Cross;
        }
        else
        {
            vseHody[index] = Turn.Player;
            whoisOn = WhoIsOn.Circle;
        }

        Invoke(nameof(ChekWin), 0.3f);
    }

    private int GetIndex(Turn t)
    {
        int v;
        for (int i = 0; i < 25; i += 5)
        {
            v = GetFreeIndex(
                new List<Turn>() { vseHody[0 + i], vseHody[1 + i], vseHody[2 + i], vseHody[3 + i], vseHody[4 + i] }, t);
            if (v != -1)
                return v + i;
        }

        for (int i = 0; i < 5; i++)
        {
            v = GetFreeIndex(
                new List<Turn>() { vseHody[0 + i], vseHody[5 + i], vseHody[10 + i], vseHody[15 + i], vseHody[20 + i] },
                t);
            if (v != -1)
                return v * 5 + i;
        }

        v = GetFreeIndex(new List<Turn>() { vseHody[0], vseHody[6], vseHody[12], vseHody[18], vseHody[24] }, t);
        if (v != -1)
            return v * 6;

        v = GetFreeIndex(new List<Turn>() { vseHody[4], vseHody[8], vseHody[12], vseHody[16], vseHody[20] }, t);
        if (v != -1)
            return (v + 1) * 4;

        return -1;
    }
}
