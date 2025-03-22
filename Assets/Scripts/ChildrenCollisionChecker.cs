using UnityEngine;

public class ChildrenCollisionChecker : MonoBehaviour
{
    //public string targetTag = "Target";
    //public string panTag = "Pan";
    public bool IsTouchingTarget_Child{get; private set;} = false;
    public bool IsTouchingPan_Child{get; private set;} = false;
    public float AbsLinearVelocities{get; private set;} = 0;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        AbsLinearVelocities = Mathf.Abs(rb.linearVelocity.x) + Mathf.Abs(rb.linearVelocity.y);
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            IsTouchingTarget_Child = true;
        }

        else if (collision.gameObject.CompareTag("Pan"))
        {
            IsTouchingPan_Child = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            IsTouchingTarget_Child = false;
        }

        else if (collision.gameObject.CompareTag("Pan"))
        {
            IsTouchingPan_Child = false;
        }
    }
}
