using UnityEngine;

public class Bulletscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider Collision)
    {
        Debug.Log("hit movefaster powerup");
        if (Collision.tag == "Projectile")

            deactivate();

    }
    void deactivate()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }




}
