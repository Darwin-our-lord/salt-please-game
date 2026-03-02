using UnityEngine;
using UnityEngine.InputSystem;

public class Hand : MonoBehaviour
{
    public static GameObject handOBJ;
    public static GameObject handSaltOBJ;
    public Sprite pinchSprite;
    public Sprite normalSprite;
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
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit == false)
            {
                handOBJ.GetComponent<SpriteRenderer>().sprite = pinchSprite;
            }
        }
        else
        {
            handOBJ.GetComponent<SpriteRenderer>().sprite = normalSprite;
        }
    }

}
