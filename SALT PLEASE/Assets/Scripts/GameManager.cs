using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Salt> salts = new List<Salt>();
    public List<Sprite> guys = new List<Sprite>();

    public SpriteRenderer guySprite;

    public Salt currentSalt;
    void Start()
    {
        NewGuy();
    }

    void NewGuy()
    {
        currentSalt = salts[Random.Range(0,salts.Count)];

        guySprite.sprite = guys[Random.Range(0, guys.Count)];





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
