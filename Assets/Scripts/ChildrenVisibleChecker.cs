using UnityEngine;

public class ChildrenVisibleChecker : MonoBehaviour
{
    public bool IsOutOfScreen_Child{get; private set;} = false;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 childPosition = mainCamera.WorldToViewportPoint(transform.position);
        if (childPosition.x < 0 || 1 < childPosition.x
            || childPosition.y < 0 || 1 < childPosition.y)
        {
            IsOutOfScreen_Child = true;
            //Debug.Log("Out of screen");
        }
        else
        {
            IsOutOfScreen_Child = false;
            //Debug.Log("In the screen");
        }
    }
}
