using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatGameManager : MonoBehaviour
{
    [SerializeField] private ChatGameInteraction chatGameInteraction;
    
    private void OnEnable()
    {
        chatGameInteraction.enabled = true;
    }
}
