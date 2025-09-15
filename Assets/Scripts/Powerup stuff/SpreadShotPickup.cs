using UnityEngine;

public class SpreadShotPickup : MonoBehaviour
{
    public SoundController theSoundController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerProjectile shooter = other.GetComponent<PlayerProjectile>();
            if (shooter != null)
            {
                shooter.ApplySpreadShot();
            }

            if (theSoundController != null)
            {
                theSoundController.buy();
            }

            Destroy(gameObject);
        }
    }
}
