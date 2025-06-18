using UnityEngine;
using System.Collections;

public class GunRaycast : MonoBehaviour
{
    public float rayDistance = 100f;   //pew pew lijn hoever
    public Camera playerCamera;
    public LineRenderer lineRenderer;   //pew pew lijn dingetje
    public float laserDuration = 0.05f;
    public Transform bulletSpawnPoint;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // hoi 
        {
            ShootRay();
        }
    }

    void ShootRay()
    {
        Ray ray = new Ray(bulletSpawnPoint.position, playerCamera.transform.forward);
        RaycastHit hit;
        Vector3 targetPoint = ray.origin + ray.direction * rayDistance;
        
        

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            targetPoint = hit.point;

            GameObject hitObject = hit.collider.gameObject;
            TriggerPlatform trigger = hitObject.GetComponent<TriggerPlatform>();

            if (trigger != null)
            {
                trigger.Activate();
            }

                switch (hitObject.tag)
                {
                    case "Target":       //target
                        Destroy(hitObject);
                        break;

                    

                    case "Enemy":     // enemy homo's
                        EnemyHit enemy = hitObject.GetComponent<EnemyHit>();
                        if (enemy != null)
                        {
                            enemy.GetShot();
                        }
                        break;
                }
        }

        
        StartCoroutine(ShowLaser(ray.origin, targetPoint));
    }

    IEnumerator ShowLaser(Vector3 start, Vector3 end)    // de hele kanker pew pew ding (hoofdpijn)
    {
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(laserDuration);

        lineRenderer.enabled = false;
    }
}
