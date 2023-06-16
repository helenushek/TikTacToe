using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class XoNobody : MonoBehaviour
{
    [FormerlySerializedAs("X")] [SerializeField] private TMP_Text x;
    [FormerlySerializedAs("O")] [SerializeField] private TMP_Text o;
    [FormerlySerializedAs("Nobody")] [SerializeField] private TMP_Text nobody;
    
    void Start()
    {
        
        if (Settings.Whoiswon == WhoisWon.X)
        {
            x.gameObject.SetActive(true);
        }
        
        if (Settings.Whoiswon == WhoisWon.O)
        {
            o.gameObject.SetActive(true);
        }
        
        if (Settings.Whoiswon == WhoisWon.Nobody)
        {
            nobody.gameObject.SetActive(true);
        }
        
    }

    
}
