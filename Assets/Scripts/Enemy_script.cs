using UnityEngine;
//use this to include AI functions for the enemy
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{

    public GameObject thePlayer;

    public float followingDistance = 5;

    public float currentDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //calculate distance between player and enemy
        currentDistance = Vector3.Distance(transform.position, thePlayer.transform.position);


        //checking if player is close enough to enemy
        //if so, update the enemy's desitnation
        if (currentDistance < followingDistance)
        {
            //set the enemy's destination to be the player's position. it will update
            //every frame
            GetComponent<NavMeshAgent>().destination = thePlayer.transform.position;
        }
        else
        {
            //if player is too far away, set the destination to the current position
            //so the enemy stop
            GetComponent<NavMeshAgent>().destination = transform.position;
        }
    }


}