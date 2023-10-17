using UnityEngine;

public class Minimizer : MonoBehaviour
{
    public float shrinkFactor = 0.3f;  // Factor to shrink the player by
    public float boostDuration = 5f;   // Duration of the minimization

    private Transform playerTransform;
    private Vector3 originalScale;
    private float boostEndTime;

    public GameObject orb;
    private float orbRespawnTime;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Grab the Transform component of the player
            playerTransform = other.transform;

            // Grab the original scale of the player
            originalScale = playerTransform.localScale;

            // Apply the shrink factor to the player's scale
            playerTransform.localScale *= shrinkFactor;

            // Set the end times for boost and orbRespawn
            boostEndTime = Time.time + boostDuration;
            orbRespawnTime = Time.time + 10f;

            // Make the orb disappear
            orb.SetActive(false);
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }


    private void Update()
    {
        if (playerTransform != null && Time.time > boostEndTime)
        {
            // Set the player's scale back to normal
            playerTransform.localScale = originalScale;
            playerTransform = null;  // Reset playerTransform reference to end the check
        }

        if (Time.time > orbRespawnTime)
        {
            // Make the orb reappear
            orb.SetActive(true);
            gameObject.GetComponent<SphereCollider>().enabled = true;
        }
    }
}
