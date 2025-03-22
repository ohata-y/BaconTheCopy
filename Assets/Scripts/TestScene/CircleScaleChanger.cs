using UnityEngine;

public class CircleScaleChanger : MonoBehaviour
{
    public float scaleSpeed = 1f;
    public float scaleRange = 1f;

    void Update()
    {
        gameObject.transform.localScale = new Vector3(Mathf.Sin(Time.time * scaleSpeed) * scaleRange, 
                                                      Mathf.Sin(Time.time * scaleSpeed) * scaleRange, 
                                                      Mathf.Sin(Time.time * scaleSpeed) * scaleRange);
    }
}
