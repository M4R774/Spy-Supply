using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    CanvasGroup group;
    Vector3 originalPosition;

    Grid2D<GameObject> new_grid;
    Grid2D<GameObject> original_grid;
    
    public string name;
    [TextArea(5,10)] public string description;
    
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
        originalPosition = transform.position;
        Transform parent = transform.parent;
        if (parent.name == "AgentInventory") {
            original_grid = parent.GetComponent<AgentInventory>().grid;
        } else {
            original_grid = parent.GetComponent<Inventory>().grid;
        }
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
            Transform superParent = collidedObject.transform.parent.parent;
            if (superParent.name == "AgentInventory") {
                new_grid = superParent.GetComponent<AgentInventory>().grid;
            } else if (superParent.name == "Inventory") {
                new_grid = superParent.GetComponent<Inventory>().grid;
            }
            // Debug.Log("Collided with " + collidedObject.name);
            bool noExistingVal = new_grid.GetValue(mousePos) == null;
            if (!collidedObject.name.Contains("Slot") || !noExistingVal)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = originalPosition + new Vector3(0, 1, 0);
            } else {
                GameObject.Find("agent_temp").GetComponent<AgentAi>().AgentBarks();
                original_grid.SetValue(originalPosition, null);
                new_grid.SetValue(mousePos, eventData.pointerDrag);
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
        return name;
    }
}
