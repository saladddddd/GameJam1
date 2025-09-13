using UnityEngine;

public class PlayerMouseVert : MonoBehaviour
{

    public float sensitivity = 9f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    float rotationX = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    {

        rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);

        transform.localEulerAngles = new Vector3(rotationX, 0, 0);

    }
}
}