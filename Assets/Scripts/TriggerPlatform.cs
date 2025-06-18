using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using System.Timers;
using System.Collections.Generic;

public class TriggerPlatform : MonoBehaviour
{

    [SerializeField] private GameObject lerpTarget;
    public GameObject cubeToRaise;
    public GameObject cubesToRaise;

    public Vector3 raisedPosition = new Vector3(0, 1, 0);
    public Vector3 raisedposition2;
    public float riseDuration = 1f;

    private bool triggered = false;
    private bool isActive;

    public void Activate()
    {
        


        if (!triggered)
        {
            triggered = true;
        }
    }
    void Start()
    {
        isActive = false;
        raisedPosition = new Vector3(cubeToRaise.transform.position.x, cubeToRaise.transform.position.y + 9f, cubeToRaise.transform.position.z);
        raisedposition2 = new Vector3(cubesToRaise.transform.position.x, cubesToRaise.transform.position.y + 9f, cubesToRaise.transform.position.z);
    }

    void Update()
    {
        if (triggered && !isActive)
        {
            lerp();
        }


        if (Vector3.Distance(cubesToRaise.transform.position, raisedPosition) < 0.05f)
        {
            isActive = true;

        }

        

        
    }

    void lerp()
    {
        cubeToRaise.transform.position = Vector3.Lerp(cubeToRaise.transform.position, raisedPosition, 5f * Time.deltaTime);
        cubesToRaise.transform.position = Vector3.Lerp(cubesToRaise.transform.position, raisedposition2, 5f * Time.deltaTime);
    }

    


}
