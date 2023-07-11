using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RingDetect : MonoBehaviour
{
    public event Action Finalized;

    [SerializeField] private float startingTime = 5f;
    [SerializeField] public int maxScore = 5;

    public float currentTime = 0f;
    public int score;
    private float timer;
    public int highscore;

    private void Start()
    {
        Time.timeScale = 1f;
        currentTime = startingTime;
        score = 0;
        timer = 0f;
        highscore = 0;
        
        highscore = PlayerPrefs.GetInt("highscore", 0);
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
      
        if (currentTime <= 0)
        {
            currentTime = 0;

            Final();
        }
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

        if (score >= maxScore)
        {
            Final();
        }
    }

    private void AddPoint()
    {
        score += 1;

        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Final()
    {
        Finalized.Invoke();

        Time.timeScale = 0f;
    }
}

