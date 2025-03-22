using UnityEngine;
using UnityEngine.UI;

public class ArrowButtonHandler : MonoBehaviour
{
    public bool ClearSceneEnd{ get; set; } = false;
    public GameObject clearImageSet;
    public GameObject filterWhite;
    public GameObject arrowButton;
    public GameObject filterPink;
    public float moveSpeed = 1;
    public float right_x = 70;
    public float left_x = -1100;
    public bool ArrowButtonClicked{ get; set; } = false;
    private RectTransform clearImageSetTransform;
    private Image arrowButtonImage;
    private Image filterPinkImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clearImageSetTransform = clearImageSet.GetComponent<RectTransform>();
        arrowButtonImage = arrowButton.GetComponent<Image>();
        filterPinkImage = filterPink.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("ClearSceneEnd: " + ClearSceneEnd);
    }

    public void Clicked()
    {
        if (filterWhite.GetComponent<FilterControllerAfterClear>().FilterAfterClearEnd)
        {
            if (!ArrowButtonClicked)
            {
                //Debug.Log("Button Clicked");
                StartCoroutine(MoveImageSet());

                arrowButtonImage.color = new Color(
                    arrowButtonImage.color.r, 
                    arrowButtonImage.color.g, 
                    arrowButtonImage.color.b, 
                    0);
                filterPinkImage.color = new Color(
                    filterPinkImage.color.r, 
                    filterPinkImage.color.g, 
                    filterPinkImage.color.b, 
                    0);

                ArrowButtonClicked = true;
            }
        }
    }

    private System.Collections.IEnumerator MoveImageSet()
    {
        while (clearImageSetTransform.anchoredPosition.x < right_x)
        {
            clearImageSetTransform.anchoredPosition = new Vector2(
                clearImageSetTransform.anchoredPosition.x + moveSpeed,
                clearImageSetTransform.anchoredPosition.y);
            yield return new WaitForSeconds(0.01f);
        }

        clearImageSetTransform.anchoredPosition = new Vector2(
            right_x, 
            clearImageSetTransform.anchoredPosition.y);

        while (clearImageSetTransform.anchoredPosition.x > left_x)
        {
            clearImageSetTransform.anchoredPosition = new Vector2(
                clearImageSetTransform.anchoredPosition.x - moveSpeed,
                clearImageSetTransform.anchoredPosition.y);
            yield return new WaitForSeconds(0.01f);
        }

        clearImageSetTransform.anchoredPosition = new Vector2(
            left_x, 
            clearImageSetTransform.anchoredPosition.y);

        ClearSceneEnd = true;
    }
}
