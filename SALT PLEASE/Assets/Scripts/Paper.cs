using TMPro;
using UnityEngine;

public class Paper : MonoBehaviour
{
    [SerializeField]
    TMP_Text textScene;
    [SerializeField]
    GameObject PaperUI;


    public void OnMouseEnter()
    {
        PaperUI.SetActive(true); 
    }
    public void OnMouseExit()
    {
        PaperUI.SetActive(false);
    }
    public void SetNewText(string txt)
    {
        textScene.text = txt;
    }
}
