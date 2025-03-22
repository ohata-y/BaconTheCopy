using UnityEngine;

public class VisibleChecker : MonoBehaviour
{
    public bool BaconIsOutOfScreen{get; private set;} = false;
    private GameObject[] childObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        childObjects = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            childObjects[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int outOfScreenCount = 0;

        foreach (GameObject childObject in childObjects)
        {
            if (childObject.GetComponent<ChildrenVisibleChecker>().IsOutOfScreen_Child)
            {
                outOfScreenCount++;
            }
        }

        if (outOfScreenCount == transform.childCount)
        {
            BaconIsOutOfScreen = true;
            //Debug.Log("Player is out of screen");
        }

        else
        {
            BaconIsOutOfScreen = false;
        }
    }
}
