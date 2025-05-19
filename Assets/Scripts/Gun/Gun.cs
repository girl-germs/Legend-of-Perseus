using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    [Header("References")]
    public Transform bulletSpawnPoint;
    public LineRenderer lineRenderer;

    [Header("Settings")]
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

           
            if (hit.collider.CompareTag("Target"))
            {
                Renderer rend = hit.collider.GetComponent<Renderer>();
                Collider col = hit.collider.GetComponent<Collider>();
                if (rend != null) rend.enabled = false;
                if (col != null) col.enabled = false;
            }

            
            if (hit.collider.CompareTag("Trigger"))
            {
                TriggerPlatform trigger = hit.collider.GetComponent<TriggerPlatform>();
                if (trigger != null)
                {
                    trigger.Activate();
                }
            }

            
            if (hit.collider.CompareTag("Enemy"))
            {
                EnemyHit enemy = hit.collider.GetComponent<EnemyHit>();
                if (enemy != null)
                {
                    enemy.GetShot();
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
