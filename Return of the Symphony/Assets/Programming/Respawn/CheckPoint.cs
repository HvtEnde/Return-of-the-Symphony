using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private RespawnScript respawn;

    void Awake()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            respawn.respawnPoint = this.gameObject;

        }    
    }
}
