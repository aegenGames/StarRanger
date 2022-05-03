using UnityEngine;

public class CameraConstSize : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] private float WidthOrHeight = 0;

    void Awake()
    {
        Camera componentCamera = GetComponent<Camera>();
        float initialSize = componentCamera.orthographicSize;
        float targetAspect = 9f / 16f;
        float constantWidthSize = initialSize * (targetAspect / componentCamera.aspect);
        componentCamera.orthographicSize = Mathf.Lerp(constantWidthSize, initialSize, WidthOrHeight);
    }
}
