using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class XONobody : MonoBehaviour
{
    [SerializeField] private TMP_Text X;
    [SerializeField] private TMP_Text O;
    [SerializeField] private TMP_Text Nobody;
    
    void Start()
    {
        
        if (Settings.Whoiswon == WhoisWon.X)
        {
            X.gameObject.SetActive(true);
        }
        
        if (Settings.Whoiswon == WhoisWon.O)
        {
            O.gameObject.SetActive(true);
        }
        
        if (Settings.Whoiswon == WhoisWon.Nobody)
        {
            Nobody.gameObject.SetActive(true);
        }
        
    }

    
}
