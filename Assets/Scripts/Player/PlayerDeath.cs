using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    #region Events
    
    public delegate void Death();

    public event Death OnDeath;

    #endregion
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnDeath?.Invoke();
        Debug.Log("Death");
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     OnDeath?.Invoke();
    //     Debug.Log("Death");
    // }
}