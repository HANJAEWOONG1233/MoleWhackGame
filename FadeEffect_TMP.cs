using System.Collections;
using UnityEngine;
using TMPro;

public class FadeEffect_TMP : MonoBehaviour
{
    [SerializeField]
    private float fadeTime = 0.5f;
    private TextMeshProUGUI fadeText;

    private void Awake()
    {
        fadeText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        StartCoroutine("FadeLoop");
    }

    private IEnumerator FadeLoop()
    {
        while (true)
        {
            yield return StartCoroutine(Fade(1f, 0f));
            yield return StartCoroutine(Fade(0f, 1f));
        }
    }

    private IEnumerator Fade(float start, float end)
    {
        float current = 0f;
        float percent = 0f;
        while (percent < 1f)
        {
            current += Time.deltaTime;
            percent = current / fadeTime;

            Color color = fadeText.color;
            color.a = Mathf.Lerp(start, end, percent);
            fadeText.color = color;

            yield return null;
        }
    }
}
