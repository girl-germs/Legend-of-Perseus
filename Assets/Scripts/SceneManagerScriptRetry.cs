using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void Loadscene(string LegendOfPerseus)
    {
        SceneManager.LoadScene(LegendOfPerseus);
    }
}
