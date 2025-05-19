using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public GameObject bloodExplosionEffect;
    public float shakeDuration = 0.3f;
    public float shakeMagnitude = 0.2f;

    public void GetShot()
{
    if (bloodExplosionEffect != null)
    {
        GameObject effect = Instantiate(bloodExplosionEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
    }

    if (CameraShake.Instance != null)
    {
        StartCoroutine(CameraShake.Instance.Shake(shakeDuration, shakeMagnitude));
    }

    Destroy(gameObject);
}

}
