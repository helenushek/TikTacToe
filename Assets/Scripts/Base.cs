using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Base : MonoBehaviour
{
    protected List<List<int>> Win;
    protected GameObject krestik;
    protected GameObject nolik;
    protected List<Turn> vseHody = new List<Turn>();
    protected WhoIsOn whoisOn;

    public void ChekWin()
    {
        for (int i = 0; i < Win.Count; i++)
        {
            List<int> podspisok = Win[i];

            bool result = ChekRow(Turn.Player, podspisok);
            bool result2 = ChekRow(Turn.Enemy, podspisok);

            if (result || result2)
            {
                if (whoisOn == WhoIsOn.Circle)
                    Settings.Whoiswon = WhoisWon.X;

                else
                    Settings.Whoiswon = WhoisWon.O;
                SceneManager.LoadScene("SomeoneWin");
            }
        }


        bool nichya = true;
        int index = 0;
        while (index < vseHody.Count)
        {
            if (vseHody[index] == Turn.None)
            {
                nichya = false;
            }

            index++;
        }

        if (nichya)
        {
            Settings.Whoiswon = WhoisWon.Nobody;
            SceneManager.LoadScene("SomeoneWin");
        }
    }
    
    private bool ChekRow(Turn hod, List<int> podspisok)
    {
        for (int j = 0; j < podspisok.Count; j++)
        {
            int index = podspisok[j];
            if (vseHody[index] != hod)
                return false;
        }
        return true;
    }
}