using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("PPCheckpoint"))
        {
            VolumeScript saturationController = FindObjectOfType<VolumeScript>();
            if (saturationController != null)
            {
                saturationController.OnCheckpointReached();
            }
        }
    }
}
