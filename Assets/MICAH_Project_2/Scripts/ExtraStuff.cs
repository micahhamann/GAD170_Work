using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExtraStuff : MonoBehaviour
{
    public Canvas mainCanvas;
    public Image redOverlay;
    public float shakeMagnitude = 10f;
    public float shakeDuration = 0.9f;
    public float flashDuration = 0.9f;
    public float flashIntensity = 0.8f;

    public void OnButtonClick()
    {
        StartCoroutine(ScreenShake());
        StartCoroutine(FlashRed());
    }
    //Used ChatGPT to try and get some screenshake happening but it didn't work
    IEnumerator ScreenShake()
    {
        Vector2 originalPos = mainCanvas.transform.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            float x = originalPos.x + Random.Range(-shakeMagnitude, shakeMagnitude);
            float y = originalPos.y + Random.Range(-shakeMagnitude, shakeMagnitude);

            mainCanvas.transform.localPosition = new Vector2(x, y);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCanvas.transform.localPosition = originalPos;
    }

    IEnumerator FlashRed()
    {
        float elapsedTime = 0f;
        Color originalColor = redOverlay.color;

        while (elapsedTime < flashDuration)
        {
            float t = Mathf.PingPong(elapsedTime * flashIntensity, 1f);
            redOverlay.color = Color.Lerp(Color.clear, Color.red, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        redOverlay.color = Color.clear;
    }
}
