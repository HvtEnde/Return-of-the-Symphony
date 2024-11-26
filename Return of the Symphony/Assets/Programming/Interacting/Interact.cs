using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.actions["Interact"].performed += OnInteract;
    }

    private void OnDisable()
    {
        
    }

    private void OnInteract(InputAction.CallbackContext callbackcontext)
    {

    }    
}
