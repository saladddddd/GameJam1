using UnityEngine;

public class PlayerMouseHor : MonoBehaviour
{
    float sensitivity = 9f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
    }
}