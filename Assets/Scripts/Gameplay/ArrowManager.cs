using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    Quaternion startRotation, targetRotation0, targetRotation1;
    float rotationTime, currentTime, t;
    bool rotateTo0;

    void Awake()
    {
        targetRotation0 = Quaternion.Euler(0,0,45);
        targetRotation1 = Quaternion.Euler(0,0,-45);
        startRotation = transform.rotation;

        rotationTime = 1f;
        currentTime = 0f;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        t = currentTime / rotationTime;
        
        if (rotateTo0)
        {
        
            if (t < 1f)
            {
                transform.rotation = Quaternion.Lerp(startRotation, targetRotation0, t);
            }
            else
            {
                rotateTo0 = false;
                currentTime = 0f;
            }
        }
        else
        {
            if (t < 1f)
            {
                transform.rotation = Quaternion.Lerp(targetRotation0, targetRotation1, t);
            }
            else
            {
                startRotation = transform.rotation;
                
                rotateTo0 = true;
                currentTime = 0f;
            }
        }
    }

    void ManipulateRotationSpeed()
    {
        
    }
}
