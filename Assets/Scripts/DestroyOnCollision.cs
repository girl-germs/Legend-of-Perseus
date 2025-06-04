using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public bool isDashing { get; private set; }
   
    [SerializeField] DashController dashController;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            dashController.enabled = true;

            isDashing = true;
        }
    }
}