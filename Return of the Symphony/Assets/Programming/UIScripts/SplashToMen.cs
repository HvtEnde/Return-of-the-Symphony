using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SplashToMen : MonoBehaviour
{
    private float timer = 5f;
    private TMP_Text timerSeconds;

    

    public void Start()
    {

        timerSeconds = GetComponent<TMP_Text>();

    }
    [System.Obsolete]
    private void Update()
    {
        timer -= Time.deltaTime;
        timerSeconds.text = timer.ToString("f0");
        if (timer <= 0)
        {
            Application.LoadLevel(1);
        }
    }
}
