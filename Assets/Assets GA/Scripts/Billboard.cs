using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update()
    {
        // Zorg dat het object altijd naar de camera kijkt
        transform.LookAt(Camera.main.transform);

        // Draai 180 graden om de juiste kant van de plane te tonen
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }
}
