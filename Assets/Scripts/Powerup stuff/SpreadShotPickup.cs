using UnityEngine;

public class SpreadShotPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerProjectile shooter = other.GetComponent<PlayerProjectile>();
            if (shooter != null)
            {
                shooter.ApplySpreadShot();
            }
            Destroy(gameObject);
        }
    }
}
