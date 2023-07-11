using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    private float currentTime = 0f;
    private float startingTime = 5f;
    [SerializeField] TMP_Text countDownText;
    [SerializeField] private GameObject ULOSE;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
            ULOSE.gameObject.SetActive(true);
      
            Time.timeScale = 0;

        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
