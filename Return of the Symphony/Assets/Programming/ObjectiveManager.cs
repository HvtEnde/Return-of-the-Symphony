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
    public bool objectivePickUp0;
    public bool objectivePickUp1;
    public bool objectivePickUp2;
    public bool objectivePickUp3;
    public bool objectivePickUp4;
    public GameObject[] objectivesToSpawn;
    public Transform[] objectiveSpawnPoint;
    public GameObject winScreen;

    public AudioClip[] musicClips;
    public AudioSource audioSource;

    public int placedOrbs;

    void Start()
    {
        maxSaturationLimit = -100;

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

    public void Interaction0()
    {
        maxSaturationLimit += 20;
        Destroy(worldObjectives[0]);
        objectivePickUp0 = true;
    }

    public void Interaction1()
    {
        maxSaturationLimit += 20;
        Destroy(worldObjectives[1]);
        objectivePickUp1 = true;
    }

    public void Interaction2()
    {
        maxSaturationLimit += 20;
        Destroy(worldObjectives[2]);
        objectivePickUp2 = true;
    }

    public void Interaction3()
    {
        maxSaturationLimit += 20;
        Destroy(worldObjectives[3]);
        objectivePickUp3 = true;
    }
    public void Interaction4()
    {
        maxSaturationLimit += 20;
        Destroy(worldObjectives[4]);
        objectivePickUp4 = true;
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

    public void WinConditionInteraction()
    {
        if (objectivePickUp0)
        {
            Instantiate(objectivesToSpawn[0], objectiveSpawnPoint[0].position, Quaternion.identity);
            placedOrbs++;
            objectivePickUp0 = false;

        }

        if (objectivePickUp1)
        {
            Instantiate(objectivesToSpawn[1], objectiveSpawnPoint[1].position, Quaternion.identity);
            placedOrbs++;
            objectivePickUp1 = false;
        }
        if (objectivePickUp2)
        {
            Instantiate(objectivesToSpawn[2], objectiveSpawnPoint[2].position, Quaternion.identity);
            placedOrbs++;
            objectivePickUp2 = false;
        }
        if (objectivePickUp3)
        {
            Instantiate(objectivesToSpawn[3], objectiveSpawnPoint[3].position, Quaternion.identity);
            placedOrbs++;
            objectivePickUp3 = false;
        }
        if (objectivePickUp4)
        {
            Instantiate(objectivesToSpawn[4], objectiveSpawnPoint[4].position, Quaternion.identity);
            placedOrbs++;
            objectivePickUp4 = false;
        }
        if (placedOrbs == 5f)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (placedOrbs == 1f)
        {
            audioSource.clip = musicClips[0];
            audioSource.Play();
        }

    }


}
