using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    private GameObject baconObject;
    public bool ScreenshotTaken { get; set; } = false;

    void Update()
    {
        baconObject = GameObject.FindWithTag("Bacon");

        if (baconObject != null)
        {
            if (!ScreenshotTaken 
                && baconObject.GetComponent<ColliderChecker>().GameClear)
            {
                StartCoroutine(TakeScreenShot());
            }
        }
    }

    private System.Collections.IEnumerator TakeScreenShot()
    {
        yield return new WaitForSeconds(0.5f);
        ScreenCapture.CaptureScreenshot("Assets/Screenshots/clear_image.png");
        yield return new WaitForSeconds(0.5f);

        ScreenshotTaken = true;
    }
}
