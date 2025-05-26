using UnityEngine;

public class RiseFromGround : MonoBehaviour
{
    public Vector3 targetPosition;
    public float riseSpeed = 2f;
    private bool rising = false;

    public void StartRise()
    {
        rising = true;
    }

    void Update()
    {
        if (rising)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, riseSpeed * Time.deltaTime);
        }
    }
}
