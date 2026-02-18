using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class SaltOBJ : MonoBehaviour
{
    private void OnMouseDrag()
    {
        transform.position = Mouse.current.position.ReadValue();
    }




}
