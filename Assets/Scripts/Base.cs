using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Base : MonoBehaviour
{
    public List<List<int>> Win;
    [FormerlySerializedAs("Krestik")] public GameObject krestik;
    [FormerlySerializedAs("Nolik")] public GameObject nolik;
    [FormerlySerializedAs("VseHody")] public List<Turn> vseHody = new List<Turn>();
    [FormerlySerializedAs("WhoisOn")] public WhoIsOn whoisOn;

    public void ChekWin()
    {
        Settings.Whoiswon = WhoisWon.Nobody;
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

        if (Settings.Whoiswon == WhoisWon.Nobody)
        {
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

