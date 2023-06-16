using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PvPBase : Base
{
    public void Init(List<Button> cells, GameObject cross, GameObject circle)
    {
        whoisOn = WhoIsOn.Cross;
        krestik = cross;
        nolik = circle;

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

    public void SetWin(List<List<int>> myWin)
    {
        Win = myWin;
    }

    

    public void OnClick(Transform button, int index)
    {
        GameObject newFigure;

        if (whoisOn == WhoIsOn.Cross && (vseHody[index] == Turn.None))
        {
            newFigure = Instantiate(krestik);
            vseHody[index] = Turn.Enemy;
            whoisOn = WhoIsOn.Circle;
        }
        else if (vseHody[index] == Turn.None)
        {
            newFigure = Instantiate(nolik);
            vseHody[index] = Turn.Player;
            whoisOn = WhoIsOn.Cross;
        }
        else return;

        Transform newFugireTransform = newFigure.GetComponent<Transform>();
        newFugireTransform.position = button.position;
        newFugireTransform.parent = button.transform;
        ChekWin();
    }
}