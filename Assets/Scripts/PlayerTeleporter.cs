using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    public Transform teleportLocation;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        

        if (hit.collider.CompareTag("KillBrick"))
        {
            Debug.Log("Teleporting!");
            transform.position = teleportLocation.position;
        }
    }
}
