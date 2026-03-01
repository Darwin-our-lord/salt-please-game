using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR;
public class SaltOBJ : MonoBehaviour
{

    public Salt salt;

    public bool isDragging = false;

    public void Start()
    {
        // GameObject kid = Instantiate(salt.saltMicroThing,transform.position,Quaternion.identity, transform);
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;

                Hand.handOBJ.SetActive(false);
                Hand.handSaltOBJ.SetActive(true);
            }
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;

            Hand.handSaltOBJ.SetActive(false);

            Hand.handOBJ.SetActive(true);

            Dissovler dissovler = FindFirstObjectByType<Dissovler>();
            if (dissovler != null)
            {
                dissovler.SpawnParticles(transform);
            }
            Destroy(gameObject);
        }
        else if (isDragging)
        {
            if(!Hand.handSaltOBJ.activeSelf) Hand.handSaltOBJ.SetActive(true);
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = transform.position.z;
            transform.position = pos;

            Hand.handSaltOBJ.transform.position = pos;
        }
    }

}
