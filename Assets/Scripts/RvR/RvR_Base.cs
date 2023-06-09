﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace RvR
{
    public class RvR_Base : Base
    {
        protected List<Button> Knopki;

        protected virtual void PcTurn()
        {
            throw new NotImplementedException();
        }

        protected virtual void InitInternal()
        {
            throw new NotImplementedException();
        }


        public IEnumerator Turns()
        {
            while (true)
            {
                PcTurn();
                yield return new WaitForSeconds(1.5f);
            }
            // ReSharper disable once IteratorNeverReturns
        }

        public void Init(List<Button> cells, GameObject cross, GameObject circle)
        {
            InitInternal();
            whoisOn = WhoIsOn.Cross;
            krestik = cross;
            nolik = circle;
            Knopki = cells;
            vseHody = new List<Turn>();

            for (int k = 0; k < cells.Count; k++)
            {
                vseHody.Add(Turn.None);
            }

            StartCoroutine(Turns());
        }

        protected int GetFreeIndex(List<Turn> turns, Turn turn)
        {
            for (int i = 0; i < turns.Count; i++)
            {
                bool isCorrect = true;
                for (int j = 0; j < turns.Count; j++)
                    if (j != i)
                    {
                        if (turns[j] != turn)
                            isCorrect = false;
                    }
                    else
                    {
                        if (turns[j] != Turn.None)
                            isCorrect = false;
                    }

                if (isCorrect)
                    return i;
            }

            return -1;
        }

        protected int GetRandomIndex()
        {
            int count = 0;

            int w = Random.Range(0, vseHody.Count);
            while (vseHody[w] != Turn.None)
            {
                w = Random.Range(0, vseHody.Count);

                if (count > 1000)
                    throw new Exception("Кол-во максимальных попыток превышено");

                count++;
            }

            return w;
        }
    }
}