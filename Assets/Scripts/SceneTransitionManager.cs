using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    private void Start()
    {
        if (fadeImage == null)
        {
            Debug.LogError("FadeImage is not assigned");
            return;
        }
        fadeImage.color = new Color(0, 0, 0, 0);
    }

    public IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1;
        fadeImage.color = color;
    }

    public IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = 1 - Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 0;
        fadeImage.color = color;
    }
}
