using UnityEngine;
using UnityEngine.UI;

public class Stage3FilterController : MonoBehaviour
{
    public Image filterImage;
    private Stage3StateController stage3StateController;
    public float alphaChangeSpeed = 1;

    void Start()
    {
        stage3StateController = gameObject.GetComponent<Stage3StateController>();

        filterImage.color = new Color(
            filterImage.color.r, 
            filterImage.color.g, 
            filterImage.color.b, 
            1);
        
        StartCoroutine(DecreaseAlpha());
    }

    private System.Collections.IEnumerator DecreaseAlpha()
    {
        while (filterImage.color.a > 0)
        {
            filterImage.color = new Color(
                filterImage.color.r, 
                filterImage.color.g, 
                filterImage.color.b, 
                filterImage.color.a - 0.01f * alphaChangeSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        stage3StateController.alphaDecreaseEnd = true;
    }
}
