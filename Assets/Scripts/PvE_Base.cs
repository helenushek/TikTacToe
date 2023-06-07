using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PvE_Base : MonoBehaviour
{
    public List<Button> knopki;

    public List<Turn> VseHody = new List<Turn>();

    public GameObject Krestik;
    public GameObject Nolik;
    public Transform Canvas;
    public FirstPlayer WhoisOn;
    public bool PervyHod = true;
    public List<List<int>> win;


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

    public void Init(List<Button> cells, GameObject Cross, GameObject Circle, Transform canvas)
    {
        InitInternal();
        WhoisOn = FirstPlayer.Cross;
        Krestik = Cross;
        Nolik = Circle;
        Canvas = canvas;
        knopki = cells;

        for (int k = 0; k < cells.Count; k++)
        {
            VseHody.Add(Turn.None);
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
        throw new System.NotImplementedException();
    }

    protected virtual void PcTurn()
    {
        throw new System.NotImplementedException();
    }

    public void OnClick(Transform button, int index)
    {
        if (PlayerTurn(button, index)) return;
        ChekWin();

        Invoke(nameof(PcTurn), 0.5f);
    }

    private bool PlayerTurn(Transform button, int index)
    {
        if (VseHody[index] != Turn.None) return true;

        GameObject newFigure = Instantiate(Krestik);
        VseHody[index] = Turn.Player;
        WhoisOn = FirstPlayer.Circle;


        Transform newFugireTransform = newFigure.GetComponent<Transform>();
        newFugireTransform.position = button.position;
        newFugireTransform.parent = button;
        return false;
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
                if (WhoisOn == FirstPlayer.Circle)
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
}