using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite full;
    public Sprite empty;

    private bool isDead = false; // Prevent multiple scene loads

    private void Update()
    {
        // Clamp health between 0 and numOfHearts
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        if (health < 0)
        {
            health = 0;
        }

        // Load death scene if health reaches 0
        if (health == 0 && !isDead)
        {
            isDead = true; // Prevent multiple calls
            SceneManager.LoadScene("death");
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = full;
            }
            else
            {
                hearts[i].sprite = empty;
            }

            hearts[i].enabled = i < numOfHearts;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered with: " + other.name); // Confirm trigger is firing

        if (other.CompareTag("evil"))
        {
            health--;
            Debug.Log("Hit by evil! Health now: " + health);
        }
    }
}