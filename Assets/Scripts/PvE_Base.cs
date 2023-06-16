using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PvEBase : Base
{
    public bool pervyHod = true;
    public List<Button> knopki;


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

    public void Init(List<Button> cells, GameObject cross, GameObject circle)
    {
        InitInternal();
        whoisOn = WhoIsOn.Cross;
        krestik = cross;
        nolik = circle;
        knopki = cells;

        for (int k = 0; k < cells.Count; k++)
        {
            vseHody.Add(Turn.None);
        }

        int i = 0;
        while (i < cells.Count)
        {
            Button copy = cells[i];
            int copyI = i;
            cells[i].onClick.AddListener(() => OnClick(copy.GetComponent<Transform>(), copyI));
            i++;
        }
    }

    protected virtual void InitInternal()
    {
        throw new NotImplementedException();
    }

    protected virtual void PcTurn()
    {
        throw new NotImplementedException();
    }

    public void OnClick(Transform button, int index)
    {
        if (PlayerTurn(button, index)) return;
        ChekWin();

        Invoke(nameof(PcTurn), 0.5f);
    }

    private bool PlayerTurn(Transform button, int index)
    {
        if (vseHody[index] != Turn.None) return true;

        GameObject newFigure = Instantiate(krestik);
        vseHody[index] = Turn.Player;
        whoisOn = WhoIsOn.Circle;


        Transform newFugireTransform = newFigure.GetComponent<Transform>();
        newFugireTransform.position = button.position;
        newFugireTransform.parent = button;
        return false;
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