using UnityEngine;

[CreateAssetMenu(fileName = "New Salt", menuName = "Salt")]
public class Salt : ScriptableObject
{
    public string saltName;

    public GameObject saltMicroThing;

    public bool disolves;

    public bool isWrong;
}
