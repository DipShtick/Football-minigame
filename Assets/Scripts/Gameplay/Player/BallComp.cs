using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class BallComp : MonoBehaviour
{
    public float speed;
    public int score, power;
    int Highscore;

    void Awake()
    {
        LostScreen.SetActive(false);
        PlayerPrefs.GetInt("Record", Highscore);
    }

    public Rigidbody2D rb;
    public Transform arrow;

    public bool ready = false;
    void FixedUpdate()
    {
        if(ready)
        {
            rb.velocity = Vector3.forward * speed * power * Time.deltaTime;
            ready = !ready;
        }
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

    bool lost = true;
    void ScoreBureaucrat()
    {
        if(scored == true)
        {
            score++;

            if(score > Highscore)
            {
                HighscoreBroken();
            }
        }
        else
        {
            score--;
        }

        if(score <= -1)
        {
            YouLose();
        }

        TextBureaucrat();
        scored = false;
    }

    TMP_Text _scoreText, _highscoreText;
    void TextBureaucrat()
    {
        _scoreText.text = score.ToString();
    }

    void HighscoreBroken()
    {
        PlayerPrefs.SetInt("Record", score);
        
        _highscoreText.text = Highscore.ToString();
    }

    void YouScored()
    {
        rb.velocity = rb.velocity * 0;


    }

    public GameObject LostScreen;
    void YouLose()
    {
        Time.timeScale = 0;
        LostScreen.SetActive(true);        
    }
}
