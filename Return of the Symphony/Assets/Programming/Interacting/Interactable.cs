using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;

public class Interactable : MonoBehaviour
{
    public float transitionSpeed = 5;
    public int saturationIncrement = 20;
    public LayerMask mask;
    public RaycastHit hit;
    public bool popupCheck;
    public GameObject popup;
    public float maxSaturationLimit;
    private float targetSaturation;

    public Volume postProcessVolume;
    private ColorAdjustments colorAdjustments;

   public Instruments instrumentInfo;
    public int currentGrabbedInstrument;
    public bool[] instrument;

    public GameObject winScreen;
    public GameObject operaBlock;
    public Transform[] instrumentSpawn;
    public GameObject winCube;
    public GameObject otherCanvas;

    public AudioSource audioSource;
    

    

    public void Start()
    {
        
        maxSaturationLimit = -100;
        if (postProcessVolume.profile.TryGet<ColorAdjustments>(out colorAdjustments))
        {
            targetSaturation = 0;
            colorAdjustments.saturation.value = -100;
        }
    }


    public void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3f, mask))
        {
            PopUp();

            if(Input.GetButtonDown("Fire1"))
            {
                if(hit.transform.tag == "TrappedInstrument")
                {
                    maxSaturationLimit += 20;
                    Destroy(hit.transform.gameObject);
                    currentGrabbedInstrument++;

                    if (currentGrabbedInstrument == 5f)
                    {
                        operaBlock.SetActive(false);
                        audioSource.Play();

                    }
                   

                }
                else if(hit.transform.tag == "WinCondition")
                {
                    if (currentGrabbedInstrument == 5)
                    {
                        Win();
                        
                    }

                    
                }
            }
            
        }  
        else
        {
            PopUpInactive();
        }

        if (colorAdjustments != null)
        {
            if (colorAdjustments.saturation.value < maxSaturationLimit)
            {
                colorAdjustments.saturation.value = Mathf.Lerp(colorAdjustments.saturation.value, targetSaturation, Time.deltaTime * transitionSpeed);

            }
        }
    }


    public void PopUp()
    {
        popupCheck = true;
        popup.gameObject.SetActive(true);
    } 

    public void PopUpInactive()
    {
        popupCheck = false;
        popup.gameObject.SetActive(false);
    }
   
    public void Win()
    {
        otherCanvas.SetActive(false);
        winCube.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        winScreen.gameObject.SetActive(true);  
    }

}
