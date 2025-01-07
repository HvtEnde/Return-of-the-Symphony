using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Timeline;

public class Andereclass : MonoBehaviour
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
    public GameObject winScreen2;
    private bool spawnedInstruments = false;

    public AudioClip[] musicClips;
    public AudioSource musicPlayer;


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

        for (int i = 0; i < objectivePickedUp.Length; i++)
        {
            Debug.Log("Hallo zoon");
            Debug.Log(finalInstruments[i].name);
            //Debug.Log(objectiveSpawnPoint[i].name);

            Debug.Log("Je moet thuiskomen voor: " + i.ToString() + " uur");
            Debug.Log(this.objectiveSpawnPoint[i]);

            Vector3 position = Vector3.zero;
            switch (i)
            {
                case 0:
                    position = new Vector3(5, 15, 9);
                    break;
                case 1:
                    position = new Vector3(4, 15, 9);
                    break;
                case 2:
                    position = new Vector3(3, 15, 9);
                    break;
                case 3:
                    position = new Vector3(2, 15, 9);
                    break;
                case 4:
                    position = new Vector3(1, 15, 9);
                    break;
            }

            Instantiate(finalInstruments[i], position, Quaternion.identity);

            if (i > 0)
            {
                Debug.Log("Hoe wsa je dag nummer: " + i.ToString());

                //musicPlayer.clip = musicClips[i];
                //musicPlayer.Play();
                if (i >= 4)
                {
                    Debug.Log("JE HEBTG EWONEN KUTNOOB");

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
