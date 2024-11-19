using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    #region Cam variables
    [SerializeField] Transform playerBody;
    public float mouseSens = 100f;
    float xRotation = 0f;
    #endregion

    /// <summary>
    /// Locks the mouse when the scene starts
    /// </summary>
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 

    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    } 






}
