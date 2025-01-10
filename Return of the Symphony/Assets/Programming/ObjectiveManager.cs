using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Timeline;

public class ObjectiveManager : MonoBehaviour
{
    public Volume postProcessVolume;
    private ColorAdjustments colorAdjustments;


    public float transitionSpeed = 5f;
    public float saturationIncrement = 20f;
    public float maxSaturationLimit;
    private float targetSaturation;
    public int saturationValue;
    public GameObject[] worldObjectives;
    public bool[] objectivePickedUp;
    public GameObject[] finalInstruments;
    public Transform[] objectiveSpawnPoint;
    public GameObject winScreen;
    private bool spawnedInstruments = false;

    public AudioClip[] musicClips;
    public AudioSource musicPlayer;
    public GameObject winCube;

    void Start()
    {

        spawnedInstruments = false;
        maxSaturationLimit = -100;
        if (postProcessVolume.profile.TryGet<ColorAdjustments>(out colorAdjustments))
        {
            targetSaturation = 0;
            colorAdjustments.saturation.value = -100;
        }
    }

    public void InteractionWithCapturedInstrument(int id)
    {
        if (!objectivePickedUp[id])
        {
            maxSaturationLimit += 20;
            Destroy(worldObjectives[id]);
            objectivePickedUp[id] = true;
        }
    }

    public void MakeTheFreedInstrumentsAppear()
    {
        Debug.Log("Hallo moeder");

        for (int i = 0; i < objectivePickedUp.Length;)
        {
           
           

            

            if (i > 0)
            {


                musicPlayer.clip = musicClips[i];
                musicPlayer.Play();
                if (i >= 4)
                {
                    

                    Winning();
                }
            }
        }
    }

    public void Winning()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        winCube.gameObject.SetActive(false);
        
    }

    void Update()
    {
        if (colorAdjustments != null)
        {
            if (colorAdjustments.saturation.value < maxSaturationLimit)
            {
                colorAdjustments.saturation.value = Mathf.Lerp(colorAdjustments.saturation.value, targetSaturation, Time.deltaTime * transitionSpeed);

            }
        }
    }
}
