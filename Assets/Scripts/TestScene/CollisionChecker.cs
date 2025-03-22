using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public float stopThreshold = 3;
    public float distanceThreshold = 0.01f;
    private GameObject[] childObjects;
    private Vector3[] lastChildPositions;
    private float stationaryTime = 0;
    private bool continueChecking = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        childObjects = new GameObject[transform.childCount];
        lastChildPositions = new Vector3[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            childObjects[i] = transform.GetChild(i).gameObject;
            lastChildPositions[i] = childObjects[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (continueChecking)
        {
            CollisionAndDistance();
        }
    }

    void CollisionAndDistance()
    {
        float totalDistance = 0;
        bool isTouchingTarget = false;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (childObjects[i].GetComponent<ChildrenCollisionChecker>().IsTouchingTarget_Child)
            {
                isTouchingTarget = true;
            }

            Vector3 currentChildPosition = childObjects[i].transform.position;
            totalDistance += Vector3.Distance(lastChildPositions[i], currentChildPosition);
            lastChildPositions[i] = currentChildPosition;
        }

        if (totalDistance < distanceThreshold)
        {
            stationaryTime += Time.deltaTime;
        }
        else
        {
            stationaryTime = 0;
        }

        if (isTouchingTarget && stationaryTime > stopThreshold)
        {
            continueChecking = false;
            ClearAction();
        }
    }

    void ClearAction()
    {
        Debug.Log("Game Clear");
    }
}
