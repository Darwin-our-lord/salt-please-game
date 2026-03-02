using TMPro;
using UnityEngine;

public class ObløslighedsTabel : MonoBehaviour
{
    [SerializeField]
    GameObject TabelUI;


    public void OnMouseEnter()
    {
        TabelUI.SetActive(true);
    }
    public void OnMouseExit()
    {
        TabelUI.SetActive(false);
    }
}
