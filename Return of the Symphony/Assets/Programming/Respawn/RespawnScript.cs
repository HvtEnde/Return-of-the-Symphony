using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;
    public PlayerManager playerManager;
    public GameObject lossScreen;
    public GameObject[] hearts;

    private void Start()
    {
        if (playerManager == null)
        {
            Debug.LogWarning("PlayerManager is not linked in RespawnScript");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.transform.position;
            if (playerManager.Lives > 1)
            {
                playerManager.Lives--;

                if(playerManager.Lives == 2)
                {
                    hearts[0].SetActive(false);
                }
                if (playerManager.Lives == 1)
                {
                    hearts[1].SetActive(false);
                }
                if (playerManager.Lives == 0)
                {
                    hearts[2].SetActive(false);
                }
            }
            else 
            {
                playerManager.IsDead = true;
                lossScreen.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
               
                    
            }


        }
    }


}
