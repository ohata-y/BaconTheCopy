using UnityEngine;

public class ReplayPlayer : MonoBehaviour
{
    public GameObject playerPrefab;
    private Vector3 playerPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        playerPosition = playerObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");

        if (playerObj == null)
        {
            GameObject newPlayerObj = Instantiate(playerPrefab, playerPosition, Quaternion.identity);
            newPlayerObj.tag = "Player";
        }
    }
}
