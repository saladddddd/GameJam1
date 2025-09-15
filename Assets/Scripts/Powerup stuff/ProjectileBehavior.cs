using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public bool piercing = false;
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            if (!piercing)
                Destroy(gameObject);
        }
        else
        {
            if (!piercing)
                Destroy(gameObject);
        }
    }
}
