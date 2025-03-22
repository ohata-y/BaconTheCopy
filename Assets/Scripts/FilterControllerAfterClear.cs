using UnityEngine;
using UnityEngine.UI;

public class FilterControllerAfterClear : MonoBehaviour
{
    public float alphaChangeSpeed = 1;
    public bool FilterAfterClearEnd { get; set; } = false;
    private Image filter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        filter = GetComponent<Image>();
        filter.color = new Color(filter.color.r, filter.color.g, filter.color.b, 1);
        StartCoroutine(ClearSceneAlpha());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private System.Collections.IEnumerator ClearSceneAlpha()
    {
        while (filter.color.a > 0)
        {
            filter.color = new Color(filter.color.r, filter.color.g, filter.color.b, filter.color.a - 0.01f);
            yield return new WaitForSeconds(0.01f / alphaChangeSpeed);
        }

        FilterAfterClearEnd = true;
    }
}
