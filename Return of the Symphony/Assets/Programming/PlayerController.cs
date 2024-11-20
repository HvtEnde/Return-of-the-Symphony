using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    #region Cam variables
    public float mouseSens = 100f;
    float xRotation = 0f;
    [SerializeField] Transform cam;
    #endregion

    #region Movement variables
    [SerializeField] float walkSpeed = 10f;
    Vector2 moveInput;
    Rigidbody myRb;
    [SerializeField] float jumpPower = 5f;
    bool isGrounded = true;
    #endregion



    /// <summary>
    /// Locks the mouse when the scene starts
    /// </summary>
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        myRb = GetComponent<Rigidbody>(); 

    }


    /// <summary>
    /// Calls on jump and run, also allows the player to move the camera
    /// </summary>
    private void Update()   
    {
        Run();

            if (Input.GetButtonDown("Jump") && isGrounded == true)
            {

            Jump();

            }
       

        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 100f);

        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);


    }

    /// <summary>
    /// Allows the players to walk
    /// </summary>
    void Run()
    {
        Vector3 playerVelocity = new Vector3(moveInput.x * walkSpeed, myRb.velocity.y, moveInput.y * walkSpeed);
        myRb.velocity = transform.TransformDirection(playerVelocity);
    }

    /// <summary>
    /// Allows the player to jump
    /// </summary>
    void Jump()
    {
        myRb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        isGrounded = false;
    }


    /// <summary>
    /// Forces player to return to the ground before jumping again
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Grounded"))
        {
            isGrounded = true;
        }
    }

    /// <summary>
    /// Gets the vector 2 of move input
    /// </summary>
    /// <param name="value"></param>
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    

  


    





}
