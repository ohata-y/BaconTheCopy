using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public Color color;
    //public float waitTime = 0.1f;
    public float fadeOutSpeed = 1;
    public GameObject scripts;
    private TextMeshProUGUI text;
    private bool isAlreadyClicked = false;
    private ArrowButtonHandler arrowButtonHandler;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        arrowButtonHandler = scripts.GetComponent<ArrowButtonHandler>();
    }

    void Update()
    {
        if (arrowButtonHandler.ArrowButtonClicked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!isAlreadyClicked)
                {
                    // Change the color of the text
                    isAlreadyClicked = true;
                    text.color = new Color(color.r, color.g, color.b, color.a);

                    // Change the color of the text to transparent
                    StartCoroutine(TextFadeOut());
                }
            }
        }
    }

    private System.Collections.IEnumerator TextFadeOut()
    {
        while (text.color.a > 0)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - 0.01f);
            yield return new WaitForSeconds(0.01f / fadeOutSpeed);
        }
    }

    //private System.Collections.IEnumerator WaitBeforeAction()
    //{
    //    yield return new WaitForSeconds(waitTime);
    //}
}
