using Unity.Collections;
using UnityEngine;

public class DestroyPlayerUsingPosition : MonoBehaviour
{
    private GameObject playerObj;
    private Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            Vector3 playerPosition = mainCamera.WorldToViewportPoint(playerObj.transform.position);
            if (playerPosition.x < 0 || 1 < playerPosition.x || 
                playerPosition.y < 0 || 1 < playerPosition.y)
            {
                Destroy(playerObj, 1);
            }
        }
    }
}
