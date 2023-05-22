using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WarningTextScript : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float fadeDuration = 2f;

    void Start()
    {
        textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
        StartCoroutine(FadeOutAndDisappear());
    }

    private System.Collections.IEnumerator FadeOutAndDisappear()
    {
        // Get the initial color of the text
        Color initialColor = textMeshPro.color;

        // Calculate the target color with zero alpha
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);

        // Calculate the current time
        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            // Increment the current time
            currentTime += Time.deltaTime;

            // Calculate the new alpha value using Lerp
            float newAlpha = Mathf.Lerp(initialColor.a, targetColor.a, currentTime / fadeDuration);

            // Set the new alpha value for the text color
            textMeshPro.color = new Color(initialColor.r, initialColor.g, initialColor.b, newAlpha);

            yield return null;
        }

        // Set the final color with zero alpha
        textMeshPro.color = targetColor;

        // Disable the text object to make it disappear completely
        Destroy(gameObject);
    }
}