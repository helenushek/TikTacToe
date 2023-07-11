using System.Collections.Generic;
using UnityEngine;

namespace RvR
{
    public class RvR_3x3 : RvR_Base
    {
        protected override void InitInternal()
        {
            Win = _winInternal;
        }

        private bool pervyHod = true;
    
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
    

        protected override void PcTurn()
        {
            bool isNolik = whoisOn == WhoIsOn.Circle;

            GameObject newFigure;
            if (isNolik)
                newFigure = Instantiate(nolik);
            else
                newFigure = Instantiate(krestik);


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

                if (isNolik)
                    vseHody[index] = Turn.Enemy;
                else
                {
                    vseHody[index] = Turn.Player;
                }
            }
            else
            {
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
            }

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

            pervyHod = false;
            Invoke(nameof(ChekWin), 0.5f);
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
}