using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    #region Interact Variables
    [SerializeField] private LayerMask interactableLayer;
    private PlayerInput playerInput;
    private Transform _transform;
    #endregion


    /// <summary>
    /// Assigns the transform and playerinput
    /// </summary>
    private void Awake()
    {
        _transform = transform;

        playerInput = GetComponent<PlayerInput>();
    }

    /// <summary>
    /// When E is pressed it adds the function of DoInteract
    /// </summary>

    private void OnEnable()
    {
        playerInput.actions["Interact"].performed += DoInteract;
    }

    /// <summary>
    /// When E is let go it takes the function of DoInteract away
    /// </summary>
    private void OnDisable()
    {
        playerInput.actions["Interact"].performed -= DoInteract;
    }

    /// <summary>
    /// Do interact function allows the raycast to see if an object has the interactable layer and allows the player to interact
    /// </summary>
    /// <param name="callbackcontext"></param>
    private void DoInteract(InputAction.CallbackContext callbackcontext)
    {
        if (!Physics.Raycast(_transform.position, _transform.forward, out var hit, 1.5f, interactableLayer)) return;

        if (!hit.transform.TryGetComponent(out InteractableObject interactable)) return;

        interactable.Interact();

        Debug.Log("Interact");
    }    
}
