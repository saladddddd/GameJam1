using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    //projectile settings
    public GameObject projectilePrefab;
    public float forwardVelocity = 20;
    public float upVelocity = 3;

    //shooting control
    public bool isShooting = false;
    public float baseFireCooldown = 0.4f;

    //active shop buffs
    public bool rapidFire = false;
    public bool piercing = false;
    public bool spreadShot = false;

    private float nextFireTime = 0f;

    void Update()
    {
        if (!isShooting) return;

        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        float cooldown = baseFireCooldown;

        if (rapidFire)
            cooldown *= 0.35f; // faster fire rate

        nextFireTime = Time.time + cooldown;

        if (spreadShot)
        {
            FireSpread();
        }
        else
        {
            SpawnProjectile(transform.forward);
        }
    }

    void FireSpread()
    {
        float spreadAngle = 15f;

        //center
        SpawnProjectile(transform.forward);

        //left
        Vector3 leftDir = Quaternion.Euler(0, -spreadAngle, 0) * transform.forward;
        SpawnProjectile(leftDir);

        //right
        Vector3 rightDir = Quaternion.Euler(0, spreadAngle, 0) * transform.forward;
        SpawnProjectile(rightDir);
    }

    void SpawnProjectile(Vector3 direction)
    {
        Vector3 thePosition = transform.TransformPoint(Vector3.forward);
        Quaternion theAngle = Quaternion.LookRotation(direction);

        GameObject createdProjectile = Instantiate(projectilePrefab, thePosition, theAngle);

        Rigidbody rb = createdProjectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * forwardVelocity + Vector3.up * upVelocity;
        }

        ProjectileBehavior proj = createdProjectile.GetComponent<ProjectileBehavior>();
        if (proj != null) proj.piercing = piercing;
    }

    public void ApplyRapidFire() => rapidFire = true;
    public void ApplyPiercing() => piercing = true;
    public void ApplySpreadShot() => spreadShot = true;
}
