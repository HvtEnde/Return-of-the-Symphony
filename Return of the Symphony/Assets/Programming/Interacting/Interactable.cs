using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;

public class Interactable : MonoBehaviour
{
    public float transitionSpeed = 5f;
    public float saturationIncrement = 20f;
    public LayerMask mask;
    public RaycastHit hit;
    public bool popupCheck;
    public GameObject popup;
    public float maxSaturationLimit;
    private float targetSaturation;

    public Volume postProcessVolume;
    private ColorAdjustments colorAdjustments;

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
                }
                else if(hit.transform.tag == "WinCondition")
                {

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
   
}
