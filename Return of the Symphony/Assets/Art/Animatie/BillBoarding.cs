using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoarding : MonoBehaviour
{
    Vector3 cD;
    // Update is called once per frame
    void Update()
    {
        cD = Camera.main.transform.forward;
        cD.y = 0;

        transform.rotation = Quaternion.LookRotation(cD);
    }
}
