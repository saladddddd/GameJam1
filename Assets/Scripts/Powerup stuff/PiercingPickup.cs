using UnityEngine;

public class PiercingPickup : MonoBehaviour
{
    public SoundController theSoundController; // assign in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerProjectile shooter = other.GetComponent<PlayerProjectile>();
            if (shooter != null)
            {
                shooter.ApplyPiercing();
            }

            if (theSoundController != null)
            {
                theSoundController.buy();
            }

            Destroy(gameObject);
        }
    }
}
