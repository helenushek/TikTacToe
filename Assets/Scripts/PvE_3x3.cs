using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PvE_3x3 : XvX_Base
{
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

    public void Init(List<Button> cells, GameObject Cross, GameObject Circle, Transform canvas)
    {
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

    public List<Turn> VseHody = new List<Turn>();

    public GameObject Krestik;
    public GameObject Nolik;
    public Transform Canvas;
    public FirstPlayer WhoisOn;
    private bool PervyHod = true;

    public void OnClick(Transform button, int index)
    {
        if (PlayerTurn(button, index)) return;
        ChekWin();
        
        PcTurn();
        ChekWin();
    }

    private bool PlayerTurn(Transform button, int index)
    {
        if (VseHody[index] != Turn.None) return true;

        GameObject newFigure = Instantiate(Krestik);
        VseHody[index] = Turn.Player;
        WhoisOn = FirstPlayer.Circle;


        Transform newFugireTransform = newFigure.GetComponent<Transform>();
        newFugireTransform.position = button.position;
        newFugireTransform.parent = Canvas;
        return false;
    }

    private void PcTurn()
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
            //TODO: защитится или выиграть матч
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
    }

    private int GetRandomIndex()
    {
        return VseHody.FindIndex(x => x == Turn.None);
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
                return 1 + i;
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

    private void ChekWin()
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