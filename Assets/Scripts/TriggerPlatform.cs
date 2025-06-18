using UnityEngine;
using System.Collections;

public class TriggerPlatform : MonoBehaviour
{
    public GameObject cubeToRaise;
    public Vector3 raisedPosition = new Vector3(0, 1, 0);
    public float riseDuration = 1f;

    private bool triggered = false;

    public void Activate()
    {
        Debug.Log("✅ TriggerScript.Activate() called");

        if (cubeToRaise == null)
        {
            Debug.LogError("❌ cubeToRaise not assigned in inspector!");
            return;
        }

        if (!triggered)
        {
            triggered = true;
            StartCoroutine(RaiseCube());
        }
    }

    private IEnumerator RaiseCube()
    {
        Vector3 start = cubeToRaise.transform.position;
        Vector3 end = raisedPosition;
        float elapsed = 0f;

        while (elapsed < riseDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / riseDuration);
            cubeToRaise.transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }

        cubeToRaise.transform.position = end;
        Debug.Log("🏁 Cube reached final position!");
    }
}
