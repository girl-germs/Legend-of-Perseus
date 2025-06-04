using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Quit : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit button pressed!");

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void Start()
    {
        Debug.Log("Quit script is active.");
    }
}
