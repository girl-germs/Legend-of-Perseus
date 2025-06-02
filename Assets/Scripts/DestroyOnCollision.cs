using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public bool isDashing { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            isDashing = true;
        }
    }
}