using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeScript : MonoBehaviour
{
    public Volume postProcessVolume;
    private ColorAdjustments colorAdjustments;


    public float transitionSpeed = 5f;
    public float saturationIncrement = 20f;
    public float maxSaturation = 0f;
    private float targetSaturation;

    void Start()
    {
        if (postProcessVolume.profile.TryGet<ColorAdjustments>(out colorAdjustments))
        {
            targetSaturation = colorAdjustments.saturation.value;
            colorAdjustments.saturation.value = -100;
        }
        else
        {
            Debug.LogError("Color Adjustment niet gevonden in volume profiel");
        }



    }
     
   
    void Update()
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.saturation.value = Mathf.Lerp(colorAdjustments.saturation.value, targetSaturation, Time.deltaTime * transitionSpeed);
        }
    }

    public void OnCheckpointReached()
    {
        if (colorAdjustments != null)
        {
            targetSaturation = Mathf.Clamp(targetSaturation + saturationIncrement,-100,maxSaturation);
        }
    }


}
