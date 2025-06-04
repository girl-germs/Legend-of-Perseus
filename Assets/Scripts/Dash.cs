using UnityEngine;
using System.Collections;

public class DashController : MonoBehaviour
{
    [Header("Dash Settings")]
    public float dashForce = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    public ParticleSystem dashEffect;
    public DashEffectUI dashZoomEffect;

    private FirstPersonMovement movementScript;
    private float dashCooldownTimer = 0f;
    private bool isDashing = false;
    private Vector3 dashDirection;

    void Start()
    {
        movementScript = GetComponent<FirstPersonMovement>();
        enabled = false;
    }

    void Update()
    {
        dashCooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimer <= 0f && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        dashCooldownTimer = dashCooldown;
        dashDirection = transform.forward;

        if (dashZoomEffect != null)
            dashZoomEffect.PlayEffect();

        if (dashEffect != null)
            dashEffect.Play();

        float elapsed = 0f;
        while (elapsed < dashDuration)
        {
            movementScript.controller.Move(dashDirection * dashForce * Time.deltaTime);
            elapsed += Time.deltaTime;
            yield return null;
        }

        isDashing = false;
    }
}
