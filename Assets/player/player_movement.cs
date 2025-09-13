using UnityEngine;

public class PlayerKeyboardMovement : MonoBehaviour
{
    //speed when you're not sprinting
    public float baseSpeed = 10f;

    //amount to add when you're sprinting
    public float sprintSpeedAdd = 5f;

    //vertical speed when you jump
    public float jumpSpeed = 5f;


    //variable for how far the ground is
    //from center of player
    public float groundDist = 1.5f;

    //add a variable to keep track of whether we're grounded
    private bool grounded = true;

    //add a layer mask to detecting the ground layer
    public LayerMask groundLayer;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //******************
        //******L/R and Forward Movement
        //******************

        float currentSpeed;

        //see if left shift is pressed in the current frame
        //not just the first frame it's pressed down
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            //shift is not pressed. not sprinting
            currentSpeed = baseSpeed;
        }
        else
        {
            //shift is pressed, so we are sprinting
            currentSpeed = baseSpeed + sprintSpeedAdd;
            Debug.Log("sprinting");
        }

        //set Z (forward) and X (sideways) speed using GetAxis
        float zspeed = Input.GetAxis("Vertical") * currentSpeed;
        float xspeed = Input.GetAxis("Horizontal") * currentSpeed;

        //******************
        //****** jumping
        //******************

        //check if we're grounded
        IsGrounded();
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Debug.Log("jump");
            //play jump sound
           
            GetComponent<Rigidbody>();
        }
        float yspeed;
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            yspeed = jumpSpeed;
        }
        else
        {
            yspeed = GetComponent<Rigidbody>().linearVelocity.y;
        }

        Vector3 movement = new Vector3(xspeed, yspeed, zspeed);

        GetComponent<Rigidbody>().linearVelocity = transform.TransformDirection(movement);

    }

    private void IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * groundDist, Color.green);
        bool hit = Physics.Raycast(transform.position, Vector3.down, groundDist, groundLayer);
        if (hit)
        {
            Debug.Log("grounded");
            grounded = true;
            //if i'm grounded, i'm not jumping
            //tell the animator component
            //GetComponent<Animator>().SetBool("IsJumping", false);
        }
        else
        {
            Debug.Log("not grounded");
            grounded = false;
            //if i'm not grounded, i am jumping
            //tell the animator component
            //GetComponent<Animator>().SetBool("IsJumping", true);
        }
    }

}