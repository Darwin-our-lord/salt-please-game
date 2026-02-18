using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<Salt> salts = new List<Salt>();
    public List<Sprite> guys = new List<Sprite>();

    public Sprite guySprite;

    public GameObject saltOBJ;

    public Salt currentSalt;

    void NewGuy()
    {
        currentSalt = salts[Random.Range(0,salts.Count)];

        guySprite = guys[Random.Range(0, guys.Count)];





    }





}
