using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public LineRenderer lineRenderer;

    public float rayDistance = 100f;
    public float laserDuration = 0.05f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        Ray ray = Camera.main.ScreenPointToRay(
            new Vector3(Screen.width / 2f, Screen.height / 2f, 0f)
        );
        RaycastHit hit;
        Vector3 targetPoint = ray.origin + ray.direction * rayDistance;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            targetPoint = hit.point;
            Debug.Log("Hit: " + hit.collider.name);

            if (hit.collider.CompareTag("Target"))
            {
                GameObject triggerObj = GameObject.Find("PlatformTrigger");
                if (triggerObj != null)
                {
                    triggerObj.GetComponent<TriggerPlatform>()?.Activate();
                }
            }
        }

        StartCoroutine(FireLaser(bulletSpawnPoint.position, targetPoint));
    }

    IEnumerator FireLaser(Vector3 start, Vector3 end)
    {
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        lineRenderer.enabled = false;
    }
}
