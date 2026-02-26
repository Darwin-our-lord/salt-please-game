using UnityEngine;

public class SaltSpawner : MonoBehaviour
{
    public GameObject saltOBJ;
    public GameManager gameManager;
    public void OnMouseDown()
    {
        GameObject slat =Instantiate(saltOBJ,transform.position,Quaternion.identity);
        slat.GetComponent<SaltOBJ>().isDragging = true;
        slat.GetComponent<SaltOBJ>().salt = gameManager.currentSalt;
        Debug.Log(slat.GetComponent<SaltOBJ>().salt);
    }
}
