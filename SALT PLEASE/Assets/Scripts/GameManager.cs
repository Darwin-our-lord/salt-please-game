using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("just references")]
    public List<Salt> salts = new List<Salt>();
    public List<Sprite> guys = new List<Sprite>();
    public Dissovler dissovler;

    public SpriteRenderer guySprite;

    public GameObject saltSpawner;
    public Paper paper;

    public Salt currentSalt;

    public GameObject lifeOBJ;

    public GameObject GameLostUI;

    public GameObject shutters;
    public GameObject handIMG;

    private GameObject saltMicroThing;

    [Header("functional stuff (from here)")]
    [SerializeField] private int livesLost = 0;
    [SerializeField] private int livesMax = 3;

    bool waitingForNewGuy = true;

    void Start()
    {
        StartCoroutine(NewGuy());
    }

    IEnumerator NewGuy()
    {
        handIMG.GetComponent<SpriteRenderer>().sortingOrder = 0;
        shutters.GetComponent<Animator>().SetTrigger("Close");

        yield return new WaitForSecondsRealtime(0.5f);

        currentSalt = salts[Random.Range(0,salts.Count)];

        guySprite.sprite = guys[Random.Range(0, guys.Count)];

        if (saltMicroThing != null) Destroy(saltMicroThing);
        saltMicroThing=Instantiate(currentSalt.saltMicroThing, saltSpawner.transform.parent.transform.position,Quaternion.identity, saltSpawner.transform.parent);

        for (int i = 0; i < saltSpawner.transform.childCount; i++)
        {
            Destroy(saltSpawner.transform.GetChild(i).gameObject);
        }

        paper.SetNewText(currentSalt.saltName);

        dissovler.KillParticles();
        dissovler.salt = currentSalt;

        yield return new WaitForSecondsRealtime(3);

        shutters.GetComponent<Animator>().SetTrigger("Open");

        yield return new WaitForSecondsRealtime(1);
        handIMG.GetComponent<SpriteRenderer>().sortingOrder = 3;
        waitingForNewGuy =false;
    }

    public void ConfirmRightOrWrong(bool isWrong)
    {
        if (waitingForNewGuy) return;
        if (currentSalt.isWrong && isWrong || !currentSalt.isWrong && !isWrong)
        {
            Right();
        }
        else
        {
            Wrong();
        }
        waitingForNewGuy = true;
        StartCoroutine(NewGuy());
    }
    void Wrong()
    {
        Debug.Log("you lose a life");
        livesLost++;
        lifeOBJ.transform.GetChild(livesLost-1).gameObject.GetComponent<Image>().color = Color.red;

        if (livesLost >= livesMax)
        {
            Debug.Log("THE GAME IS LOST   -   X");
            GameLostUI.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
        }



    }
    void Right()
    {
        Debug.Log("you win");




    }
}
