using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimplePlayButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            Debug.Log("Play button clicked!");
            SceneManager.LoadScene("Game");
        });
    }
}
