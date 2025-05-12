using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DashEffectUI : MonoBehaviour
{
    public float fadeInTime = 0.05f;
    public float fadeOutTime = 0.2f;

    private Image img;
    private Coroutine currentRoutine;

    void Start()
    {
        img = GetComponent<Image>();
        SetAlpha(0f);
    }

    public void PlayEffect()
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);
        currentRoutine = StartCoroutine(PlayEffectRoutine());
    }

    IEnumerator PlayEffectRoutine()
    {
        float t = 0f;
        while (t < fadeInTime)
        {
            t += Time.deltaTime;
            SetAlpha(Mathf.Lerp(0, 1, t / fadeInTime));
            yield return null;
        }

        t = 0f;
        while (t < fadeOutTime)
        {
            t += Time.deltaTime;
            SetAlpha(Mathf.Lerp(1, 0, t / fadeOutTime));
            yield return null;
        }

        SetAlpha(0f);
    }

    void SetAlpha(float a)
    {
        if (img == null) return;
        Color c = img.color;
        c.a = a;
        img.color = c;
    }
}
