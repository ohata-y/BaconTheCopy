using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        Debug.Log(player.GetComponent<Rigidbody2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
