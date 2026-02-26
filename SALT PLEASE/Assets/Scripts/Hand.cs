using UnityEngine;
using UnityEngine.InputSystem;

public class Hand : MonoBehaviour
{
    public static GameObject handOBJ;
    public static GameObject handSaltOBJ;
    void Awake()
    {
        Cursor.visible = false;
        handOBJ = this.gameObject;
        handSaltOBJ = this.transform.parent.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        Vector3 d = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        d.z = 0;
        transform.position = d;
    }
}
