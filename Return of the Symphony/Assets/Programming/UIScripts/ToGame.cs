using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToGame : MonoBehaviour
{
    [System.Obsolete]
    public void ToMainGame()
    {
        Application.LoadLevel(1);
    }
}
