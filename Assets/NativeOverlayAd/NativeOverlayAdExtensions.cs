using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

namespace One.Ad.Admob.NativeOverlay
{
    public static class NativeOverlayAdExtensions
    {
        public static float DpPerPixel => 160f / GetDPI();

        public static float GetDPI()
        {
            float dpi = Screen.dpi;

            // Nếu dpi không xác định (một số thiết bị trả về 0), gán mặc định
            if (dpi == 0f)
            {
                dpi = 160f; // giả định mật độ chuẩn mdpi
            }

            return dpi;
        }

        public static void RenderTemplate(this NativeOverlayAd nativeOverlayAd, NativeTemplateStyle nativeTemplateStyle, RectTransform placementTarget, Canvas canvas)
        {
            if (placementTarget == null || canvas == null)
                return;

            Vector2 adSize = new Vector2(placementTarget.rect.width * placementTarget.localScale.x, placementTarget.rect.height * placementTarget.localScale.y);
            Debug.Log(adSize);
            Debug.Log(adSize * DpPerPixel);
            Vector2 adPos = (canvas.renderMode == RenderMode.ScreenSpaceOverlay) ?
                placementTarget.position :
                canvas.worldCamera.WorldToScreenPoint(placementTarget.position);
            adPos.y = Screen.height - adPos.y;  // fix vị trí trục y
            adPos -= adSize / 2;    // fix vị trí theo kích thước
            adPos *= DpPerPixel;
            Debug.Log(adPos);

            nativeOverlayAd.RenderTemplate(nativeTemplateStyle, new AdSize((int)adSize.x, (int)adSize.y), (int)adPos.x, (int)adPos.y);

            Debug.Log(nativeOverlayAd.GetTemplateWidthInPixels() + " " + nativeOverlayAd.GetTemplateHeightInPixels());
        }

        public static AdSize AdSize(RectTransform rt)
        {
            return new AdSize((int)(rt.rect.width * rt.localScale.x), (int)(rt.rect.height * rt.localScale.y));
        }

        public static Vector2Int AdPosition(RectTransform rt, Canvas canvas)
        {
            Vector2 adPos = (canvas.renderMode == RenderMode.ScreenSpaceOverlay) ?
                rt.position :
                canvas.worldCamera.WorldToScreenPoint(rt.position);

            adPos.y = Screen.height - adPos.y;  // fix vị trí trục y
            adPos -= new Vector2(rt.rect.width, rt.rect.height) / 2;    // fix vị trí theo kích thước
            adPos *= DpPerPixel;

            return new Vector2Int((int)adPos.x, (int)adPos.y);
        }
    }
}