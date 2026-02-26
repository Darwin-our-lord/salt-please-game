using UnityEngine;

public class SaltSpawner : MonoBehaviour
{
    public GameObject saltOBJ;

    public void OnMouseDown()
    {
        GameObject slat =Instantiate(saltOBJ,transform.position,Quaternion.identity);
        slat.GetComponent<SaltOBJ>().isDragging = true;
    }
}
