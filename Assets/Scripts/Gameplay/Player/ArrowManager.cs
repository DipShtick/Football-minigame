using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArrowManager : MonoBehaviour
{
    Quaternion startRotation, targetRotation0, targetRotation1;
    public float rotationTime;
    float currentTime, t;
    bool rotateTo0;

    void Awake()
    {
        targetRotation0 = Quaternion.Euler(0,0,155);
        targetRotation1 = Quaternion.Euler(0,0,25);
        startRotation = transform.rotation;

        rotationTime = 1f;
        currentTime = 0f;
    }

    void Update()
    {
        // For the rotation
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

        // For input
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            PowerBureaucrat();
        }
        else if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0))
        {
            Launch();
        }
        else if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    bool maxed = false;
    int power, maxPower = 50, minPower = 1;
    void PowerBureaucrat()
    {
        if(power == maxPower)
        {
            maxed = true;
            power--;
        }
        else if(maxed)
        {
            power--;
        }
        else if(power == minPower && maxed)
        {
            Launch();
            maxed = false;
        }
        else
        {
            power++;
        }
        
        CalculatePower();
    }

    public Slider powerSlider;
    void CalculatePower()
    {
        powerSlider.value = power/maxPower;
    }

    public BallComp ball;
    void Launch()
    {
        power = ball.power;
        ball.ready =! ball.ready;
    }
}
