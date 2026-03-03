using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

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

    private GameObject saltMicroThing;

    [Header("functional stuff (from here)")]
    [SerializeField] private int livesLost = 0;
    [SerializeField] private int livesMax = 3;


    void Start()
    {
        NewGuy();
    }

    void NewGuy()
    {
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
    }

    public void ConfirmRightOrWrong(bool isWrong)
    {
        if (currentSalt.isWrong && isWrong || !currentSalt.isWrong && !isWrong)
        {
            Right();
        }
        else
        {
            Wrong();
        }
        NewGuy();
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
        }



    }
    void Right()
    {
        Debug.Log("you win");




    }
}
