using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderChecker : MonoBehaviour
{
    public bool GameClear{get; private set;} = false;
    private GameObject scripts;
    private ChildrenCollisionChecker[] childCollisionCheckers;
    private Rigidbody2D[] childRigidbodies;
    private float totalAbsLinearVelocities;
    private bool isTouchingTarget;
    private bool isTouchingPan;

    void Start()
    {
        childCollisionCheckers = new ChildrenCollisionChecker[transform.childCount];
        childRigidbodies = new Rigidbody2D[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            childCollisionCheckers[i] = transform.GetChild(i).GetComponent<ChildrenCollisionChecker>();
            childRigidbodies[i] = transform.GetChild(i).GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        totalAbsLinearVelocities = 0;
        isTouchingTarget = false;
        isTouchingPan = false;

        for (int i = 0; i < transform.childCount; i++)
        {
            totalAbsLinearVelocities += childCollisionCheckers[i].AbsLinearVelocities;

            if (childCollisionCheckers[i].IsTouchingTarget_Child)
            {
                isTouchingTarget = true;
            }

            if (childCollisionCheckers[i].IsTouchingPan_Child)
            {
                isTouchingPan = true;
            }
        }

        if (isTouchingTarget && !isTouchingPan)
        {
            //Debug.Log(totalAbsLinearVelocities);

            if (totalAbsLinearVelocities < 0.1f)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    childRigidbodies[i].linearDamping = 100;
                }

                Debug.Log("Game Clear");
                GameClear = true;

                scripts = GameObject.FindWithTag("Scripts");

                if (scripts.GetComponent<ScreenShot>().ScreenshotTaken)
                {
                    // Load the next scene
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                }

                // Load the next scene
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
        }
    }
}
