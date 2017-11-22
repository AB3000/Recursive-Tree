using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class drag2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

    public static GameObject beginItem;
    Vector3 startPos;
    Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        beginItem = gameObject;
        startPos = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        beginItem = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent==startParent)
        {
            transform.position = startPos;
        }


    }
}
