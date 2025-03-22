using UnityEngine;

public class FryingPanSimulator : MonoBehaviour
{
    public float maxRotation = 15;
    public float minRotation = 345;
    // rotation per frame
    public float rotationSpeed = 1;
    public bool IsMovingUpward {get; private set;} = false;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, minRotation);
    }

    void FixedUpdate()
    {
        var currentAngle = transform.rotation.eulerAngles.z;

        if (Input.GetMouseButton(0))
        {
            var angleAfterMove = currentAngle + rotationSpeed;

            if (angleAfterMove >= 360)
            {
                angleAfterMove -= 360;
            }

            if (minRotation <= angleAfterMove || angleAfterMove <= maxRotation)
            {
                transform.Rotate(0, 0, rotationSpeed);
                IsMovingUpward = true;
            }
            else
            {
                IsMovingUpward = false;
            }
        }

        else
        {
            var angleAfterMove = currentAngle - rotationSpeed;

            if (angleAfterMove < 0)
            {
                angleAfterMove += 360;
            }
            
            if (minRotation <= angleAfterMove || angleAfterMove <= maxRotation)
            {
                transform.Rotate(0, 0, -rotationSpeed);
                IsMovingUpward = false;
            }
        }
    }
}
