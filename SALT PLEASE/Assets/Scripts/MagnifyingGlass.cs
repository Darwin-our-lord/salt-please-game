using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;

public class MagnifyingGlass : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

    public GameObject laying;
    public GameObject holding;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();




    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        holding.SetActive(true);
        laying.SetActive(false);
        Debug.Log("stuff");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Camera eventCamera = eventData.pressEventCamera;

        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(
                rectTransform,
                eventData.position,
                eventCamera,
                out Vector3 worldPoint))
        {
            rectTransform.position = worldPoint;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        holding.SetActive(false);
        laying.SetActive(true);
    }
}