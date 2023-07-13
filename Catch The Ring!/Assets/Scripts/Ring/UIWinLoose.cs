using System.Collections;
using UnityEngine;

public class UIWinLoose : MonoBehaviour
{
    [SerializeField] private RingDetect RingDetect;

    [SerializeField] private CanvasGroup UWIN;
    [SerializeField] private CanvasGroup ULOSE;

    private float fadeSpeed = 0.05f;

    private void Awake()
    {
        RingDetect.Finalized += ShowFinalScreen;
    }

    private void OnDestroy()
    {
        RingDetect.Finalized -= ShowFinalScreen;
    }

    private void ShowFinalScreen()
    {
        if (RingDetect.score >= RingDetect.maxScore)
        {
            StartCoroutine(FadeCanvasGroup(UWIN));
        }
        else
        {
            StartCoroutine(FadeCanvasGroup(ULOSE));
        }
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup)
    {
        canvasGroup.gameObject.SetActive(true);

        for (float a = 0; a < 1f; a += fadeSpeed)
        {
            canvasGroup.alpha = a;

            yield return null;
        }
        Cursor.lockState = CursorLockMode.None;

        canvasGroup.alpha = 1f;
    }
}
