using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class BallComp : MonoBehaviour
{
    float speed, power;
    int score, minPower, maxPower;

    Slider powerSlider;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            power++;
        }
    }

    void PowerBureaucrat()
    {
        if(power == maxPower)
        {
            power--;
        }
        else if(power == minPower)
        {
            Launch();
        }
    }

    void Launch()
    {

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
