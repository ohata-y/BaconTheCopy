using UnityEngine;

public class RespawnBacon : MonoBehaviour
{
    public GameObject baconPrefab;

    private GameObject baconObject;
    private Vector3 baconPosition;

    void Start()
    {
        GameObject baconObject = GameObject.FindWithTag("Bacon");
        baconPosition = baconObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        baconObject = GameObject.FindWithTag("Bacon");
        if (baconObject == null)
        {
            Instantiate(baconPrefab, baconPosition, Quaternion.identity);
            //GameObject newPlayerObj = Instantiate(baconPrefab, baconPosition, Quaternion.identity);
            //newPlayerObj.tag = "Player";
        }
    }
}
