using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData pointerEventData) {
        if (pointerEventData != null) {
            
            CameraController controller = Camera.main.GetComponent<CameraController>();
            Mission current = controller.current_mission;
            // If original position was agent inventory, remove from mission luggage
            if (pointerEventData.pointerDrag.transform.parent.name == "AgentInventory") {
                current.RemoveItemFromLuggage(pointerEventData.pointerDrag);
            }
            pointerEventData.pointerDrag.transform.SetParent(GetComponent<RectTransform>().gameObject.transform.parent.parent);

            // If the new target is agent inventory, add to mission luggage
            Transform parent = GetComponent<RectTransform>().gameObject.transform.parent;
            if (parent.name == "AgentInventorySlots") {
                current.AddItemToLuggage(pointerEventData.pointerDrag);
            }
            pointerEventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            // Debug.Log("Items on mission: " + current.luggage.Count);
        }
    }
}
