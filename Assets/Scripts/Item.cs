using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    CanvasGroup group;
    Vector3 originalPosition;
    // Start is called before the first frame update

    private void Awake()
    {
        group = GetComponent<CanvasGroup>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().anchoredPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 1, 0);
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
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(transform.position + new Vector3(0, 0, -1), transform.TransformDirection(Vector3.forward), out hit, 100f);
    GameObject collidedObject;
        if (hit.collider != null)
        {
            collidedObject = hit.collider.gameObject;
            Debug.Log("Collided with " + collidedObject.name);
            if (!collidedObject.name.Contains("Slot"))
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = originalPosition;
            }
        }
        else
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = originalPosition;
        }

        Debug.Log("Ended drag");
        group.blocksRaycasts = true;
        group.alpha = 1f;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Ended drag");
    }
    public string name;
    [TextArea(5,10)]
    public string description;

    Item(string name_parameter, string description_parameter)
    {
        name = name_parameter;
        description = description_parameter;
    }

    // For testing
    Item()
    {
        name = "testi itemi";
        description = "rakentajalle ei annettu parametreja joten luotiin vain tyhjä itemi";
    }

    public string GetName()
    {
        return name;
    }
}
