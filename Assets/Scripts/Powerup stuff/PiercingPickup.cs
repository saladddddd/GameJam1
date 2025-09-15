using UnityEngine;

public class PiercingPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerProjectile shooter = other.GetComponent<PlayerProjectile>();
            if (shooter != null)
            {
                shooter.ApplyPiercing();
            }
            Destroy(gameObject);
        }
    }
}
