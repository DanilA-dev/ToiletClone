using UnityEngine;

public class SafeAreaView : MonoBehaviour
{
    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.WindowsEditor ||
            Application.platform == RuntimePlatform.IPhonePlayer)
            UpdateSafeArea();
    }

    private void UpdateSafeArea()
    {
        var safeArea = Screen.safeArea;
        var rect = GetComponent<RectTransform>();

        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMax.x /= Screen.width;

        anchorMax.y /= Screen.height;
        anchorMin.y /= Screen.height;

        rect.anchorMin = anchorMin;
        rect.anchorMax = anchorMax;
    }
}
