using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace One.UI
{
    public class ResizeUI : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;

        public void OnChange(float value)
        {
            rectTransform.localScale = Vector3.one * value;
        }
    }
}