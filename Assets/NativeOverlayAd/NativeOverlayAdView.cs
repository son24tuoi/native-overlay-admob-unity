using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace One.Ad.Admob.NativeOverlay
{
    [RequireComponent(typeof(NativeOverlayAdController))]
    public class NativeOverlayAdView : MonoBehaviour
    {
        [SerializeField] private NativeOverlayAdController nativeOverlayAdController;
        [SerializeField] private RectTransform adPlacementTarget;
        [SerializeField] private Canvas canvas;

        private readonly WaitForSecondsRealtime wait = new WaitForSecondsRealtime(1f);

        private void Reset()
        {
            nativeOverlayAdController = GetComponent<NativeOverlayAdController>();
            adPlacementTarget = GetComponent<RectTransform>();
            canvas = GetComponentInParent<Canvas>();
        }

        private void Start()
        {
            nativeOverlayAdController.LoadAd();
            StartCoroutine(IEWaitRenderAd());
        }

        private IEnumerator IEWaitRenderAd()
        {
            while (!nativeOverlayAdController.IsRendered)
            {
                nativeOverlayAdController.RenderAdPlacmentTarget(adPlacementTarget, canvas);
                yield return wait;
            }
        }

        public void LoadAd()
        {
            Start();
        }

        public void HideAd()
        {
            nativeOverlayAdController.HideAd();
        }
    }
}