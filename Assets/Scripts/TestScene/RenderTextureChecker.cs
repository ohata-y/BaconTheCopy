using UnityEngine;

public class RenderTextureChecker : MonoBehaviour
{
    public Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"width: {Screen.width}, height: {Screen.height}");
        RenderTexture renderTexture = new RenderTexture(1080, 2340, 24);
        mainCamera.targetTexture = renderTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
