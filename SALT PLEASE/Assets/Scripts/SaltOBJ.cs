using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class SaltOBJ : MonoBehaviour
{
    private void OnMouseDrag()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);

    }
}
