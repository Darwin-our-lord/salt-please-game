using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Salt> salts = new List<Salt>();
    public List<Sprite> guys = new List<Sprite>();

    public SpriteRenderer guySprite;

    public GameObject saltSpawner;

    public Salt currentSalt;

    private GameObject saltMicroThing;
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
    }

    public void ConfirmRightOrWrong(bool isWrong)
    {
        if (currentSalt.isWrong && isWrong)
        {
            Debug.Log("you win");

        }
        else if (currentSalt.isWrong && !isWrong)
        {
            Debug.Log("you win");
        }
        else
        {
            Debug.Log("you lose");
        }
        NewGuy();
    }
}
