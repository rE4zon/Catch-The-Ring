using TMPro;
using UnityEngine;

public class UIRingDetect : MonoBehaviour
{
    [SerializeField] private RingDetect RingDetect;
    [Space]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highscoreText;
    [SerializeField] private TMP_Text countDownText;

    private void Awake()
    {
        RingDetect.Finalized += HideScore;
    }

    private void OnDestroy()
    {
        RingDetect.Finalized -= HideScore;
    }

    private void Update()
    {
        scoreText.text = "POINTS: " + RingDetect.score.ToString();
        highscoreText.text = "HIGHSCORE: " + RingDetect.highscore.ToString();
        countDownText.text = RingDetect.currentTime.ToString("0");
    }

    private void HideScore()
    {
        scoreText.gameObject.SetActive(false);
        highscoreText.gameObject.SetActive(false);
        countDownText.gameObject.SetActive(false);
    }
}
