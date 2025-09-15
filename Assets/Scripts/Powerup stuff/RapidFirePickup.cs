using UnityEngine;

public class RapidFirePickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerProjectile shooter = other.GetComponent<PlayerProjectile>();
            if (shooter != null)
            {
                shooter.ApplyRapidFire();
            }
            Destroy(gameObject);
        }
    }
}
