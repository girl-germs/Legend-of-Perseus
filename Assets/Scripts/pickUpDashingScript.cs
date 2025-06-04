using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class pickUpDashingScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<DashController>().enabled = false;
    }

    void Update()
    {
        
    }
}
