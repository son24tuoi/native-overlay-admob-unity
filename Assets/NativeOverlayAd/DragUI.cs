using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace One.UI
{
    public class DragUI : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;

        private PointerEventData pointerData;

        private void Reset()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnBeginDrag(BaseEventData data)
        {
            // Debug.Log("beginnnnnnnnnn");
        }

        public void OnDrag(BaseEventData data)
        {
            pointerData = (PointerEventData)data;
            rectTransform.anchoredPosition += pointerData.delta;
        }

        public void OnEndDrag(BaseEventData data)
        {
            // Debug.Log("endddd");

        }
    }
}
