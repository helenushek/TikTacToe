using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PvP_Base : MonoBehaviour
{
    public void Init(List<Button> cells, GameObject Cross, GameObject Circle, Transform canvas)
    {
        WhoisOn = FirstPlayer.Cross;
        Krestik = Cross;
        Nolik = Circle;
        Canvas = canvas;

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
    public void SetWin(List<List<int>> myWin)
    {
        win = myWin;
    }
    public List<Turn> VseHody = new List<Turn>();

    public GameObject Krestik;
    public GameObject Nolik;
    public Transform Canvas;
    public FirstPlayer WhoisOn;
    private List<List<int>> win;

    public void OnClick(Transform button, int index)
    {
        GameObject newFigure;

        if (WhoisOn == FirstPlayer.Cross && (VseHody[index] == Turn.None))
        {
            newFigure = Instantiate(Krestik);
            VseHody[index] = Turn.Enemy;
            WhoisOn = FirstPlayer.Circle;
        }
        else if (VseHody[index] == Turn.None)
        {
            newFigure = Instantiate(Nolik);
            VseHody[index] = Turn.Player;
            WhoisOn = FirstPlayer.Cross;
        }
        else return;

        Transform newFugireTransform = newFigure.GetComponent<Transform>();
        newFugireTransform.position = button.position;
        newFugireTransform.parent = Canvas;
        ChekWin();
    }
    

    private void ChekWin()
    {
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
