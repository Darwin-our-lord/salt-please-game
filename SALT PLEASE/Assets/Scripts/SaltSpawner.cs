using UnityEngine;

public class SaltSpawner : MonoBehaviour
{
    public GameObject saltOBJ;

    public void OnMouseDown()
    {
        Instantiate(saltOBJ);
    }
}
