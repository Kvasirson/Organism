using System.Collections;
using UnityEngine;
using TMPro;

public class TextMeshProBlink : MonoBehaviour
{
    private TextMeshProUGUI textMeshProComponent;
    public float fadeDuration = 1.0f; // Duration in seconds for the fade.
    public AnimationCurve fadeCurve = AnimationCurve.Linear(0, 0, 1, 1); // Animation curve for the fade.

    private void Start()
    {
        textMeshProComponent = GetComponent<TextMeshProUGUI>();
        StartCoroutine(FadeText());
    }

    private IEnumerator FadeText()
    {
        float startTime = Time.time;
        float originalSize = textMeshProComponent.fontSize;
        float endSize = originalSize * 0.7f;
        Color startColor = textMeshProComponent.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0); 

        while (Time.time - startTime < fadeDuration)
        {
            float t = (Time.time - startTime) / fadeDuration;
            float curveValue = fadeCurve.Evaluate(t);
            textMeshProComponent.color = Color.Lerp(startColor, endColor, curveValue);
            textMeshProComponent.fontSize = Mathf.Lerp(originalSize, endSize, curveValue);
            yield return null;
        }

        // Wait for a moment after the text becomes completely invisible before making it reappear.
        yield return new WaitForSeconds(0.5f); // Wait for 1 second before reappearing.

        // Fade-in the text.
        startTime = Time.time;
        while (Time.time - startTime < fadeDuration)
        {
            float t = (Time.time - startTime) / fadeDuration;
            float curveValue = fadeCurve.Evaluate(t);
            textMeshProComponent.color = Color.Lerp(endColor, startColor, curveValue);
            textMeshProComponent.fontSize = Mathf.Lerp(endSize, originalSize, curveValue);
            yield return null;
        }

        // Ensure that the text is fully opaque at the end.
        textMeshProComponent.color = startColor;

        // Restart the fade routine to create a loop.
        StartCoroutine(FadeText());
    }
}
