using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject platformToRaise;
    public Vector3 targetPosition = new Vector3(0, 0, 0);
    public float riseSpeed = 2f;

    private bool isActivated = false;

    public void Activate()
    {
        if (!isActivated)
        {
            isActivated = true;
            StartCoroutine(RaisePlatform());
        }
    }

    System.Collections.IEnumerator RaisePlatform()
    {
        if (platformToRaise == null)
        {
            Debug.LogWarning("No platform assigned!");
            yield break;
        }

        Vector3 startPos = platformToRaise.transform.position;

        while (Vector3.Distance(platformToRaise.transform.position, targetPosition) > 0.01f)
        {
            platformToRaise.transform.position = Vector3.MoveTowards(
                platformToRaise.transform.position,
                targetPosition,
                riseSpeed * Time.deltaTime
            );
            yield return null;
        }

        platformToRaise.transform.position = targetPosition;
    }
}
