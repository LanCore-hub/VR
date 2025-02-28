using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ViolationEffect : MonoBehaviour
{
    public UnityEngine.UI.Image flashImage;
    public Color flashColor = new Color(1, 0, 0, 0.5f);
    public float flashDuration = 0.5f;

    public void TriggerFlash()
    {
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        float elapsedTime = 0f;
        Color startColor = Color.clear;
        Color endColor = flashColor;

        while (elapsedTime < flashDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / (flashDuration / 2);
            flashImage.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        elapsedTime = 0f;
        while (elapsedTime < flashDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / (flashDuration / 2);
            flashImage.color = Color.Lerp(endColor, startColor, t);
            yield return null;
        }

        flashImage.color = Color.clear;
    }
}
