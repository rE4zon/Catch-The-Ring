using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RingDetect : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highscoreText;
    

    private float score;
    private float timer;
    private float highscore;

    private void Start()
    {
        score = 0f;
        timer = 0f;
        highscore = 0f;
        
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        highscore = PlayerPrefs.GetFloat("highscore", 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                AddPoint();
                timer -= 1f;
            }
        }

        if (score >= 100)
        {
            EndGame();
        }
    }

    private void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";

        if(highscore < score)
        {
            PlayerPrefs.SetFloat("highscore", score);
        }
    }

    private void EndGame()
    {
        
        Debug.Log("Game Over");
    }

}
