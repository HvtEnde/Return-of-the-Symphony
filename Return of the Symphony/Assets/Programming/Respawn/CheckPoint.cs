using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public RespawnScript respawn;

    public Transform checkPoint;
    public bool reachedCheckPoint;

    private void Start()
    {
        if (respawn == null)
        {
            Debug.LogWarning("respawnscript not linked in ChechPoints");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        if (!reachedCheckPoint)
        {
            respawn.respawnPoint = checkPoint;

            reachedCheckPoint = true;
        }
    }


}
