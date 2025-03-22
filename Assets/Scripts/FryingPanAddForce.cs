using UnityEngine;

public class FryingPanAddForce : MonoBehaviour
{
    public float power = 1;
    private Vector2 force;
    //private float fryingPanLastAngle_z;
    private float fryingPanCurrentAngle_z;
    //private GameObject playerObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fryingPanCurrentAngle_z = transform.localEulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        fryingPanCurrentAngle_z = transform.localEulerAngles.z;

        //if (270 < fryingPanCurrentAngle_z && fryingPanCurrentAngle_z < 360)
        //{
        //    fryingPanCurrentAngle_z -= 360;
        //}
        
        //if (270 < fryingPanLastAngle_z && fryingPanLastAngle_z < 360)
        //{
        //    fryingPanLastAngle_z -= 360;
        //}
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("BaconBone"))
        {
            //Debug.Log("Collided with Player");
            if (gameObject.GetComponent<FryingPanSimulator>().IsMovingUpward)
            {
                float force_x = Mathf.Cos((fryingPanCurrentAngle_z + 90) * Mathf.Deg2Rad);
                float force_y = Mathf.Sin((fryingPanCurrentAngle_z + 90) * Mathf.Deg2Rad);

                force = new Vector2(force_x, force_y) * power;

                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
                
                //Debug.Log("Force Added");

                //playerObject = GameObject.FindWithTag("Player");

                //if (playerObject != null)
                //{
                //    foreach (Rigidbody2D child in playerObject.GetComponentsInChildren<Rigidbody2D>())
                //    {
                //        child.AddForce(force, ForceMode2D.Impulse);
                //        Debug.Log("Force Added");
                //    }
                //}

                //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
                //Debug.Log("Force Added");

                //for (int i = 0; i < collision.transform.childCount; i++)
                //{
                //    Transform child = collision.transform.GetChild(i);
                //    child.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
                //}
                //Debug.Log(transform.childCount);
            }
        }
    }
}
