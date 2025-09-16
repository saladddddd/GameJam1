using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class SimpleZombie : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;
    public Transform target;

    [Header("Health")]
    public int health = 3;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, lookRotation, Time.fixedDeltaTime * 5f));
        }

        float distance = moveSpeed * Time.fixedDeltaTime;
        if (!Physics.Raycast(transform.position + Vector3.up * 0.5f, transform.forward, distance + 0.1f))
        {
            rb.MovePosition(rb.position + transform.forward * distance);
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + Vector3.up * 0.5f, transform.position + Vector3.up * 0.5f + transform.forward * (moveSpeed * Time.fixedDeltaTime + 0.1f));
    }
}
