using TMPro;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public float pickupRange = 2f; // How close the player needs to be to pick up coins
    public static int score = 0; // Static variable for score
    public TextMeshProUGUI scoreText; // UI Text to show score

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickupNearbyCoin();
        }
    }

    void TryPickupNearbyCoin()
    {
        // Detect all colliders within range
        Collider[] hits = Physics.OverlapSphere(transform.position, pickupRange);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Coin"))
            {
                // Optionally play sound
                AudioSource audio = hit.GetComponent<AudioSource>();
                if (audio != null)
                {
                    audio.Play();
                }

                // Increase score
                score++;
                UpdateScoreUI();

                // Destroy the coin (after delay if sound is playing)
                Destroy(hit.gameObject, audio != null ? audio.clip.length : 0f);

                // Only pick up one coin at a time
                break;
            }
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}