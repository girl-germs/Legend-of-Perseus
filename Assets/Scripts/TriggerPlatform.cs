using UnityEngine;
using System.Collections;

public class TriggerPlatform : MonoBehaviour
{
    public GameObject platformToRaise;
    public Vector3 raisedPosition = new Vector3(0, 1, 0);
    public float riseDuration = 1f;

    private bool triggered = false;

    public void Activate()
    {
        Debug.Log("TriggerPlatform.Activate() called");
        if (!triggered)
        {
            triggered = true;
            StartCoroutine(RaisePlatform());
        }
    }

    private IEnumerator RaisePlatform()
    {
        Vector3 startPos = platformToRaise.transform.position;
        Vector3 endPos = raisedPosition;

        float elapsed = 0f;

        while (elapsed < riseDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / riseDuration);
            platformToRaise.transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        platformToRaise.transform.position = endPos;
    }
}
