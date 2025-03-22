using UnityEngine;
using UnityEngine.UI;

public class FilterController : MonoBehaviour
{
    public float alphaChangeSpeed = 1;
    public GameObject scripts;
    private Image backgroundImage;
    //private bool sceneStarted = false;
    private bool alreadyClicked = false;
    private float currentAlpha = 1;
    private ArrowButtonHandler arrowButtonHandler;
    private bool alphaAlreadyStartChanging = false;

    void Start()
    {
        arrowButtonHandler = scripts.GetComponent<ArrowButtonHandler>();
        backgroundImage = GetComponent<Image>();
        backgroundImage.color =new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, currentAlpha);
        //sceneStarted = true;
    }

    void Update()
    {
        if (arrowButtonHandler.ArrowButtonClicked)
        {
            if (!alphaAlreadyStartChanging)
            {
                // The alpha value of the filter declines gradually from 1 to 0.5
                StartCoroutine(StartSceneAlpha());
                alphaAlreadyStartChanging = true;
            }

            if (!alreadyClicked)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    // The alpha value of the filter declines immediately to 0
                    // It means that the filter is removed
                    alreadyClicked = true;
                    backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, 0);
                }
            }
        }
    }

    private System.Collections.IEnumerator StartSceneAlpha()
    {
        while (backgroundImage.color.a > 0.5)
        {
            currentAlpha -= 0.01f;
            backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, currentAlpha);
            yield return new WaitForSeconds(0.01f / alphaChangeSpeed);
        }
    }
}
