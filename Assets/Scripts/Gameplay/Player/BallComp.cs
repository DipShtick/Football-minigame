using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class BallComp : MonoBehaviour
{
    float speed, power;
    int score, minPower, maxPower;

    public Slider powerSlider;

    void Awake()
    {
        maxPower = 10;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            PowerBureaucrat();
        }
        else if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0))
        {
            Launch();
        }
    }

    bool maxed;
    void PowerBureaucrat()
    {
        if(power == maxPower)
        {
            maxed = true;
            power--;
        }
        else if(power == minPower && maxed)
        {
            Launch();
        }
        else
        {
            power++;
        }
    }

    void CalculatePower()
    {
        powerSlider.value = power/maxPower;
    }

    Rigidbody2D rb;
    public Transform arrow;
    void Launch()
    {
        rb.velocity = Time.deltaTime * arrow.rotation.z * rb.velocity * power;
    }

    bool scored;
    Collider2D colinfo;
    void OnTriggerEnter2D(Collider2D col)
    {
        colinfo = col;

        if(col.gameObject.tag == "Net")
        {
            scored = true;
        }
        else
        {
            scored = false;
        }


        ScoreBureaucrat();
    }

    void ScoreBureaucrat()
    {
        if(scored == true)
        {
            score++;
        }
        else
        {
            scored = false;
        }
    }

    void TextBureaucrat()
    {

    }
}
