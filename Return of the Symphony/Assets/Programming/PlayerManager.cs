using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] int _lives;
    bool _isDead;

   
    
    public int Lives
    {
        get{ return _lives; }
        set { _lives = value; }
    }

    public bool IsDead
    {
        get { return _isDead; }
        set { _isDead = value; }
    }
}
