using UnityEngine;

public class SaltSpawner : MonoBehaviour
{
    public GameObject saltOBJ;
    public GameManager gameManager;
    public void OnMouseDown()
    {
        GameObject slat =Instantiate(saltOBJ,transform.position,Quaternion.identity,transform);
        slat.GetComponent<SaltOBJ>().isDragging = true;
        slat.GetComponent<SaltOBJ>().salt = gameManager.currentSalt;
        Hand.handOBJ.SetActive(false);
    }
}
