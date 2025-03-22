using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Color color;
    public float startWidth = 0;
    public float maxWidth = 1500;
    public float transformSpeed = 1;
    public float fadeOutSpeed = 1;
    public GameObject scripts;
    //public float waitTimeBeforeExpand = 0;
    //public float waitTimeBeforeDisapper = 0;
    private Image image;
    private bool isAlreadyClicked = false;
    private bool isAlreadyExpanded = false;
    private ArrowButtonHandler arrowButtonHandler;

    void Start()
    {
        arrowButtonHandler = scripts.GetComponent<ArrowButtonHandler>();
        image = GetComponent<Image>();
        image.rectTransform.sizeDelta = new Vector2(startWidth, image.rectTransform.sizeDelta.y);

        // Wait for a while before the image expands
        //StartCoroutine(WaitBeforeExpand());

        // Expand the width of the image
        //StartCoroutine(ExpandWidth());
    }

    void Update()
    {
        if (arrowButtonHandler.ArrowButtonClicked)
        {
            if (!isAlreadyExpanded)
            {
                // Expand the width of the image
                StartCoroutine(ExpandWidth());
                isAlreadyExpanded = true;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (!isAlreadyClicked)
                {
                    // Change the color of the image
                    isAlreadyClicked = true;
                    image.color = new Color(color.r, color.g, color.b, color.a);

                    // Change the color of the image to transparent
                    StartCoroutine(ImageFadeOut());
                }
            }
        }
    }

    private System.Collections.IEnumerator ExpandWidth()
    {
        while (image.rectTransform.sizeDelta.x < maxWidth)
        {
            image.rectTransform.sizeDelta = new Vector2(image.rectTransform.sizeDelta.x + 10, image.rectTransform.sizeDelta.y);
            yield return new WaitForSeconds(0.01f / transformSpeed);
        }
    }

    //private System.Collections.IEnumerator WaitBeforeExpand()
    //{
    //    yield return new WaitForSeconds(waitTimeBeforeExpand);
    //}

    //private System.Collections.IEnumerator WaitBeforeDisapper()
    //{
    //    yield return new WaitForSeconds(waitTimeBeforeDisapper);
    //}

    private System.Collections.IEnumerator ImageFadeOut()
    {
        //StartCoroutine(WaitBeforeDisapper());

        while (image.color.a > 0)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - 0.01f);
            yield return new WaitForSeconds(0.01f / fadeOutSpeed);
        }
    }
}
