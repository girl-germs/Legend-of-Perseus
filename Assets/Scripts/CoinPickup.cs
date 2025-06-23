using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            ScoreManager.instance.AddScore(scoreValue);

          
            Destroy(gameObject);
        }
    }
}