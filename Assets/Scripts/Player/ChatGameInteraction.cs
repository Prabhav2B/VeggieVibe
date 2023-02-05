using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ChatGameInteraction : MonoBehaviour
{
    [SerializeField] private PlayerActions _playerActions;
    [SerializeField] private GestureBehavior _gestureBehavior;

    [SerializeField] private Transform _playerTransform;
    
    void Start()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        _gestureBehavior.OnSwipe += MovePlayer;
    }
    
    private void OnDisable()
    {
        _gestureBehavior.OnSwipe -= MovePlayer;
    }
    
    private void MovePlayer(GestureBehavior.Direction dir)
    {
        Vector3 targetPosition = Vector3.zero;
        
        if(dir == GestureBehavior.Direction.down || dir == GestureBehavior.Direction.up)
            return;

        if (dir == GestureBehavior.Direction.left)
            targetPosition = new Vector3(-1.5f, 3.04f, 0f);
        else if (dir == GestureBehavior.Direction.right)
            targetPosition = new Vector3(1.5f, 3.04f, 0f);

        _playerTransform.DOMove(targetPosition, .1f);

    }
}
