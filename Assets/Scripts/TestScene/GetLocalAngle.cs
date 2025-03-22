using UnityEngine;

public class GetLocalAngle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float zAngle = transform.localEulerAngles.z;
        Debug.Log(zAngle);
    }
}
