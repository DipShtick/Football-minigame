using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OpeningScreen : MonoBehaviour
{
    public Light2D BacLight;
    float fadeSpeed = 0.1f;
    float targetIntensity = 1.0f;

    void Awake()
    {
        BacLight.intensity = 0f;
    }

    void Update()
    {
        // Increment the intensity of the light by the fade speed
        BacLight.intensity += fadeSpeed * Time.deltaTime;

        //Skips the lighting part
        if(Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetKey(KeyCode.Space))
        {
            BacLight.intensity = targetIntensity + fadeSpeed;
        }

        // If the intensity has reached the target value, stop fading
        if (BacLight.intensity >= targetIntensity)
        {
            BacLight.intensity = targetIntensity;
            StartCoroutine(AnimationPlayer());

            enabled = false;
        }
    }

    public Animator P, O, Q;
    IEnumerator AnimationPlayer()
    {
        Q.SetBool("Qmoment", true);
        yield return new WaitForSecondsRealtime(0.5f);

        O.SetBool("Omoment", true);
        yield return new WaitForSecondsRealtime(0.5f);

        P.SetBool("Pmoment", true);
    }
}
