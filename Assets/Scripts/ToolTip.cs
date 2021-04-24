 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.EventSystems;
 
 public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
 
        [Tooltip ("UI components to show or hide.")]
        [SerializeField]
        protected GameObject toolTipComponent;
 
        [Tooltip ("If true toolTipComponent will be moved to mouse position.")]
        [SerializeField]
        protected bool moveTipToMousePosition;
 
        protected Vector2 lastPosition;
 
        const float ToolTipDelay = 0.25f;
 
        const float MouseMoveLeeway = 100.0f;
 
        public void OnPointerEnter(PointerEventData eventData)
        {
            StopAllCoroutines ();
            StartCoroutine (CheckForHover ());
        }
 
        public void OnPointerExit(PointerEventData eventData)
        {
            StopAllCoroutines ();
            Hide();
        }
 
        public void Show () {
            if (moveTipToMousePosition) {
                MoveToolTipToMousePosition ();
            }
            toolTipComponent.SetActive (true);
            StartCoroutine (CheckForCancel());
        }
 
        public void Hide () {
            toolTipComponent.SetActive (false);
        }
 
        protected void MoveToolTipToMousePosition() {
            // Note this works for screen overlay only
            toolTipComponent.transform.position = new Vector2((int)Input.mousePosition.x, (int) Input.mousePosition.y);
        }
 
        protected IEnumerator CheckForHover () {
            float timeStill = 0.0f;
            lastPosition = Input.mousePosition;
            yield return true;
            while (timeStill < ToolTipDelay) {
                if (Vector2.Distance(lastPosition, Input.mousePosition) > MouseMoveLeeway) {
                    timeStill = 0;
                } else {
                    timeStill += Time.deltaTime;
                }
                lastPosition = Input.mousePosition;
                yield return true;
            }
            Show ();
        }
 
        protected IEnumerator CheckForCancel () {
            lastPosition = Input.mousePosition;
            yield return true;
            while (Vector2.Distance(lastPosition, Input.mousePosition) < MouseMoveLeeway) {
                yield return true;
            }
            Hide ();
        }
    }