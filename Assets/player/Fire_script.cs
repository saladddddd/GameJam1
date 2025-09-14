using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float forwardVelocity = 20;
    public float upVelocity = 3;
    public bool isShooting = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        //check if we pressed the mouse
        if (isShooting == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 thePosition = transform.TransformPoint(Vector3.forward);
                Quaternion theAngle = transform.rotation * Quaternion.Euler(90, 0, 0);
                //create the projectile in front of the player
                GameObject createdProjectile = Instantiate(projectilePrefab, thePosition, theAngle);

                //set it's velocity
                createdProjectile.GetComponent<Rigidbody>().linearVelocity = transform.forward * forwardVelocity + Vector3.up * upVelocity;
                ;
            }
        }
        else _ = isShooting == false;

    }
}