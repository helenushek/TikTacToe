using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PvP
{
    public class PvP_Base : Base
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

            for (int i = 0; i < cells.Count; i++)
            {
                Button copy = cells[i];
                var copyI = i;
                cells[i].onClick.AddListener(() => OnClick(copy.GetComponent<Transform>(), copyI));
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
}