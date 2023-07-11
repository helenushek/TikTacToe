using System.Collections.Generic;
using UnityEngine;

namespace RvR
{
    public class RvR_4x4 : RvR_Base
    {
        protected override void InitInternal()
        {
            Win = _winInternal;
        }
        private List<List<int>> _winInternal = new List<List<int>>()
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

            Invoke(nameof(ChekWin), 0.5f);
        }

        private int GetIndex(Turn t)
        {
            int v;
            for (int i = 0; i < 16; i += 4)
            {
                v = GetFreeIndex(new List<Turn>() { vseHody[0 + i], vseHody[1 + i], vseHody[2 + i], vseHody[3 + i] }, t);
                if (v != -1)
                    return v + i;
            }

            for (int i = 0; i < 4; i++)
            {
                v = GetFreeIndex(new List<Turn>() { vseHody[0 + i], vseHody[4 + i], vseHody[8 + i], vseHody[12 + i] }, t);
                if (v != -1)
                    return v * 4 + i;
            }

            v = GetFreeIndex(new List<Turn>() { vseHody[0], vseHody[5], vseHody[10], vseHody[15] }, t);
            if (v != -1)
                return v * 5;

            v = GetFreeIndex(new List<Turn>() { vseHody[3], vseHody[6], vseHody[9], vseHody[12] }, t);
            if (v != -1)
                return (v + 1) * 3;

            return -1;
        }
    }
}