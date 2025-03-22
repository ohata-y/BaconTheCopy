using UnityEngine;

public class DestroyBacon : MonoBehaviour
{
    public float timeOut = 1;
    private GameObject baconObject;
    private GameObject scriptsObject;
    private bool alreadyDestroyed = false;

    void Start()
    {
        scriptsObject = GameObject.FindWithTag("Scripts");
    }

    void Update()
    {
        baconObject = GameObject.FindWithTag("Bacon");

        if (baconObject != null && !alreadyDestroyed)
        {
            if (baconObject.GetComponent<VisibleChecker>().BaconIsOutOfScreen
                && !scriptsObject.GetComponent<HandMover>().HandHoldingBacon)
            {
                Destroy(baconObject, timeOut);
                alreadyDestroyed = true;
                Debug.Log("Bacon destroyed");
            }
        }

        else
        {
            alreadyDestroyed = false;
        }
    }
}
