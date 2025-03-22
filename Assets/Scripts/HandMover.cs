using UnityEditor.EditorTools;
using UnityEngine;

public class HandMover : MonoBehaviour
{
    [Tooltip("Speed of the hand.")]
    public float moveSpeed = 1;
    [Tooltip("Speed of the rotation of the fingers.")]
    public float rotationSpeed = 1;
    [Tooltip("How much the fingers should rotate to open.")]
    public float rotation = 10;
    [Tooltip("Final position_x of the hand.\nThe bacon moves along with the hand.")]
    public float finalPosition_x = 0;
    [Tooltip("Transform of the sum finger.")]
    public Transform sumFingerTransform;
    [Tooltip("Transform of the index finger.")]
    public Transform indexFingerTransform;
    [Tooltip("Prefab of the bacon.\nNote that the prefab should be chosen from the Assets, not the Scene.")]
    public GameObject baconPrefab;
    //public GameObject baconBone1;
    public GameObject scripts;
    private DistanceJoint2D baconBone1DistanceJoint;
    public bool HandHoldingBacon{get; private set;} = true;

    private float totalRotation;
    private bool movingRight = false;
    private bool moveRightFinished = false;
    private bool movingLeft = false;
    private bool moveLeftFinished = false;
    private Transform handParentTransform;
    private Transform baconParentTransform;
    private Transform[] baconBoneTransforms;
    private float baconBone1InitialDistance;
    private Vector3 baconParentInitialPosition;
    private GameObject baconObject;
    private float handParentInitialPosition_x;
    private ArrowButtonHandler arrowButtonHandler;

    void Start()
    {
        // Transform of the hand (parent)
        // is used to move the hand left and right
        handParentTransform = GameObject.FindWithTag("Hand").GetComponent<Transform>();
        handParentInitialPosition_x = handParentTransform.position.x;

        // Distance Joint 2D of bacon_bone_1
        // is used to control the connection between the hand and the bacon
        baconBone1DistanceJoint = GameObject.Find("bacon_bone_1").GetComponent<DistanceJoint2D>();

        // Initial distance of bacon_bone_1
        // is used to move the bacon left and right
        baconBone1InitialDistance = baconBone1DistanceJoint.distance;

        // Transform of the bacon (parent)
        // is used to refer to its children
        baconParentTransform = GameObject.FindWithTag("Bacon").GetComponent<Transform>();

        // Initial position of bacon (parent)
        // is used to instantiate the bacon
        baconParentInitialPosition = baconParentTransform.position;

        // Transforms of bacon_bones
        // are used to move the bacon left and right
        baconBoneTransforms = new Transform[baconParentTransform.childCount];
        for (int i = 0; i < baconParentTransform.childCount; i++)
        {
            baconBoneTransforms[i] = baconParentTransform.GetChild(i);
        }

        arrowButtonHandler = scripts.GetComponent<ArrowButtonHandler>();
    }


    void Update()
    {
        baconObject = GameObject.FindWithTag("Bacon");

        // If the bacon isn't in the scene, instantiate it
        if (baconObject == null)
        {
            Instantiate(baconPrefab, baconParentInitialPosition, Quaternion.identity);
            //Debug.Log("Bacon instantiated");

            // Reset the values of the flags
            HandHoldingBacon = true;
            moveRightFinished = false;
            movingRight = false;
            moveLeftFinished = false;
            movingLeft = false;

            baconBone1DistanceJoint = GameObject.Find("bacon_bone_1").GetComponent<DistanceJoint2D>();
            baconParentTransform = GameObject.FindWithTag("Bacon").GetComponent<Transform>();
            baconBoneTransforms = new Transform[baconParentTransform.childCount];
            for (int i = 0; i < baconParentTransform.childCount; i++)
            {
                baconBoneTransforms[i] = baconParentTransform.GetChild(i);
            }

            // Start moving right
            StartCoroutine(MoveRight());
        }

        // If the bacon is in the scene, control the hand and the bacon depending on input
        else
        {
            if (arrowButtonHandler.ArrowButtonClicked)
            {
                if (Input.GetMouseButtonDown(0) && !moveRightFinished && !movingRight)
                {
                    StartCoroutine(MoveRight());
                }

                if (Input.GetMouseButtonDown(0) && moveRightFinished && !moveLeftFinished && !movingLeft)
                {
                    StartCoroutine(OpenFingersAndMoveLeft());
                }
            }
        }
    }

    private System.Collections.IEnumerator MoveRight()
    {
        movingRight = true;
        float relativeDistance = handParentInitialPosition_x - baconBone1DistanceJoint.connectedAnchor.x;

        while (handParentTransform.position.x + 0.01f * moveSpeed < finalPosition_x)
        {
            handParentTransform.position = new Vector3(handParentTransform.position.x + 0.01f * moveSpeed, 
                                                       handParentTransform.position.y, 
                                                       0);
            //Debug.Log("Hand moving right");

            baconBone1DistanceJoint.connectedAnchor = new Vector2(baconBone1DistanceJoint.connectedAnchor.x + 0.01f * moveSpeed, 
                                                                  baconBone1DistanceJoint.connectedAnchor.y);
            baconBone1DistanceJoint.distance = baconBone1InitialDistance;
            //Debug.Log($"baconbone1 {baconBone1DistanceJoint.connectedAnchor.x} {baconBone1DistanceJoint.connectedAnchor.y}");

            // Somehow the bacon's DistanceJoint2D can't remain the initial distance
            // and it stretches like a spring
            // To avoid this, each bacon's bone should also be moved along with the hand
            if (handParentTransform.position.x + 0.01f * moveSpeed <= finalPosition_x - 0.1f)
            {
                for (int i = 0; i < baconBoneTransforms.Length; i++)
                {
                    baconBoneTransforms[i].position = new Vector3(baconBoneTransforms[i].position.x + 0.01f * moveSpeed, 
                                                                  baconBoneTransforms[i].position.y, 
                                                                  0);
                }
            }
            
            yield return new WaitForSeconds(0.01f);
        }

        // The position doens't necessarily reach the final position 
        // even if handParentTransform.position.x + 0.01f * moveSpeed <= finalPosition_x
        // so that the position should manually be set to the final position after the loop
        handParentTransform.position = new Vector3(finalPosition_x, 
                                                   handParentTransform.position.y, 
                                                   0);

        baconBone1DistanceJoint.connectedAnchor = new Vector2(finalPosition_x - relativeDistance, 
                                                              baconBone1DistanceJoint.connectedAnchor.y);
        baconBone1DistanceJoint.distance = baconBone1InitialDistance;

        //Debug.Log("Hand moved right");
        moveRightFinished = true;
        movingRight = false;
    }

    private System.Collections.IEnumerator MoveLeft()
    {
        movingLeft = true;

        while (handParentTransform.position.x - 0.01f * moveSpeed > handParentInitialPosition_x)
        {
            handParentTransform.position = new Vector3(handParentTransform.position.x - 0.01f * moveSpeed, 
                                                       handParentTransform.position.y, 
                                                       0);
            
            yield return new WaitForSeconds(0.01f);
        }

        // Adjust the position
        handParentTransform.position = new Vector3(handParentInitialPosition_x, 
                                                   handParentTransform.position.y, 
                                                   0);

        //Debug.Log("Hand moved left");
        moveLeftFinished = true;
        movingLeft = false;

        CloseFingers();
    }

    private System.Collections.IEnumerator OpenFingers()
    {
        HandHoldingBacon = false;
        totalRotation = 0;

        while (totalRotation + 0.01f * rotationSpeed < rotation)
        {
            sumFingerTransform.Rotate(0, 0, -0.01f * rotationSpeed);
            indexFingerTransform.Rotate(0, 0, 0.01f * rotationSpeed);

            totalRotation += 0.01f * rotationSpeed;

            yield return new WaitForSeconds(0.01f);
        }

        sumFingerTransform.Rotate(0, 0, rotation - totalRotation);
        indexFingerTransform.Rotate(0, 0, -rotation + totalRotation);

        //Debug.Log("Fingers opened");
    }

    private System.Collections.IEnumerator OpenFingersAndMoveLeft()
    {
        // Release the bacon
        baconBone1DistanceJoint.enabled = false;

        yield return StartCoroutine(OpenFingers());
        yield return StartCoroutine(MoveLeft());
    }

    void CloseFingers()
    {
        sumFingerTransform.Rotate(0, 0, rotation);
        indexFingerTransform.Rotate(0, 0, -rotation);
        //Debug.Log("Fingers closed");
    }
}
