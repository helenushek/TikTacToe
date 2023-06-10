using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EvE_3x3 : MonoBehaviour
{
    public GameObject Krestik;
    public GameObject Nolik;
    public Transform Canvas;
    public bool PervyHod = true;
    public List<Turn> VseHody;
    public WhoIsOn WhoisOn;

    public IEnumerator turns()
    {
        while (true)
        {
            PcTurn();
            yield return new WaitForSeconds(1.5f);
        }
    }

    public void Init(List<Button> cells, GameObject Cross, GameObject Circle, Transform canvas)
    {
        WhoisOn = WhoIsOn.Cross;
        Krestik = Cross;
        Nolik = Circle;
        Canvas = canvas;
        knopki = cells;
        VseHody = new List<Turn>();

        for (int k = 0; k < cells.Count; k++)
        {
            VseHody.Add(Turn.None);
        }
        StartCoroutine(turns());
    }

    private bool ChekRow(Turn hod, List<int> podspisok)
    {
        for (int j = 0; j < podspisok.Count; j++)
        {
            int index = podspisok[j];
            if (VseHody[index] != hod)
                return false;
        }

        return true;
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

            if (isCorrect == true)
                return i;
        }


        return -1;
    }

    protected int GetRandomIndex()
    {
        int count = 0;

        int w = Random.Range(0, VseHody.Count);
        while (VseHody[w] != Turn.None)
        {
            w = Random.Range(0, VseHody.Count);

            if (count > 1000)
                throw new Exception("Кол-во максимальных попыток превышено");

            count++;
        }

        return w;
    }

    public void ChekWin()
    {
        Settings.Whoiswon = WhoisWon.Nobody;
        for (int i = 0; i < win.Count; i++)
        {
            List<int> podspisok = win[i];

            bool result = ChekRow(Turn.Player, podspisok);
            bool result2 = ChekRow(Turn.Enemy, podspisok);

            if (result || result2)
            {
                if (WhoisOn == WhoIsOn.Circle)
                    Settings.Whoiswon = WhoisWon.X;

                else
                    Settings.Whoiswon = WhoisWon.O;
                SceneManager.LoadScene("SomeoneWin");
            }
        }

        if (Settings.Whoiswon == WhoisWon.Nobody)
        {
            bool Nichya = true;
            int index = 0;
            while (index < VseHody.Count)
            {
                if (VseHody[index] == Turn.None)
                {
                    Nichya = false;
                }

                index++;
            }

            if (Nichya == true)
            {
                Settings.Whoiswon = WhoisWon.Nobody;
                SceneManager.LoadScene("SomeoneWin");
            }
        }
    }

    private List<List<int>> win = new List<List<int>>()
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

    private List<Button> knopki;

    void PcTurn()
    {
        bool isNolik = WhoisOn == WhoIsOn.Circle;

        GameObject newFigure;
        if (isNolik)
            newFigure = Instantiate(Nolik);
        else
            newFigure = Instantiate(Krestik);


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

            if (isNolik)
                VseHody[index] = Turn.Enemy;
            else
            {
                VseHody[index] = Turn.Player;
            }
        }
        else
        {
            int value;
            if (isNolik)
                value = GetIndex(Turn.Enemy);
            else
                value = GetIndex(Turn.Player);

            if (value == -1)
            {
                value = GetRandomIndex();
            }
            
            index = value;
        }

        Transform newFugireTransform = newFigure.GetComponent<Transform>();
        newFugireTransform.position = knopki[index].transform.position;
        newFugireTransform.parent = Canvas;
        if (isNolik)
        {
            VseHody[index] = Turn.Enemy;
            WhoisOn = WhoIsOn.Cross;
        }
        else
        {
            VseHody[index] = Turn.Player;
            WhoisOn = WhoIsOn.Circle;
        }

        PervyHod = false;
        Invoke(nameof(ChekWin), 0.5f);
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