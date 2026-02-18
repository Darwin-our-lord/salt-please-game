using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class SaltOBJ : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(eventData.position).x, 
            Camera.main.ScreenToWorldPoint(eventData.position).y,0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
