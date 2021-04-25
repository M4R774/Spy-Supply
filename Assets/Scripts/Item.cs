using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    CanvasGroup group;
    Vector3 originalPosition;
    
    public string item_name;
    [TextArea(5,10)] public string description;
    
    Item(string name_parameter, string description_parameter)
    {
        item_name = name_parameter;
        description = description_parameter;
    }

    // For testing
    Item()
    {
        item_name = "testi itemi";
        description = "rakentajalle ei annettu parametreja joten luotiin vain tyhjä itemi";
    }

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
        // Debug.Log("Began drag");
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
            // Debug.Log("Collided with " + collidedObject.name);
            if (!collidedObject.name.Contains("Slot"))
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = originalPosition + new Vector3(0, 1, 0);
            } else {
                GameObject.Find("agent_temp").GetComponent<AgentAi>().AgentBarks();
            }
        }
        else
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = originalPosition + new Vector3(0, 1, 0);
        }

        group.blocksRaycasts = true;
        group.alpha = 1f;
    }

    public string GetName()
    {
        return item_name;
    }
}
