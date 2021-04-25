using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    CanvasGroup group;
    Vector3 originalPosition;
  // Start is called before the first frame update

    private void Awake() {
        group = GetComponent<CanvasGroup>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().anchoredPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Began drag");
        originalPosition = transform.position;
        group.blocksRaycasts = false;
        group.alpha = 0.6f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Input.mousePosition;
        RaycastHit hit;
        Physics.Raycast(transform.position + new Vector3(0, 0, -1), transform.TransformDirection(Vector3.forward), out hit, 10f);
        GameObject collidedObject;
        if (hit.collider != null) {
        collidedObject = hit.collider.gameObject;
        Debug.Log("Collided with " + collidedObject.name);
        if (!collidedObject.name.Contains("Slot"))
        {
            // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = originalPosition;
        }
        } else {
            // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = originalPosition;
        }
        
        Debug.Log("Ended drag");
        group.blocksRaycasts = true;
        group.alpha = 1f;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Ended drag");
    }
}
