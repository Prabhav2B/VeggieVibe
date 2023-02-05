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
        _playerActions.OnTap += CheckHeart;
    }

    private void CheckHeart(Vector2 position)
    {
        //if (GameManager.instance.startSwiping) return;

        Ray ray = _playerActions.GetScreenToWorldRay();
        RaycastHit2D[] hit2D = Physics2D.GetRayIntersectionAll(ray);

        foreach (var hit in hit2D)
        {
            if (hit.collider.gameObject.CompareTag("Heart"))
            {
                hit.collider.transform.parent.GetComponent<GreenFlag>().HeartClicked();
            }
        }
    }

    private void OnDisable()
    {
        _gestureBehavior.OnSwipe -= MovePlayer;
        _playerActions.OnTap -= CheckHeart;
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
