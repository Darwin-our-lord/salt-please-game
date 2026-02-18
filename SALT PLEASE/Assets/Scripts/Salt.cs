using UnityEngine;

[CreateAssetMenu(fileName = "New Salt", menuName = "Salt")]
public class Salt : ScriptableObject
{
    public string saltName;

    public Sprite saltSprite;
    public bool disolves;

    public bool isWrong;
}
