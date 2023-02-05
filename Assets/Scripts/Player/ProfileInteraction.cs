using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;

public class ProfileInteraction : MonoBehaviour
{
    [SerializeField] private PlayerActions playerActions;

    private Camera mainCam;
    private Coroutine profileCoroutine;
    private Transform profileTransform;
    private Vector3 profileStartPosition;

    private bool dragActive;
    private Tween dragTween;

    private void Awake()
    {
        mainCam = Camera.main;
        dragActive = false;
    }

    private void OnEnable()
    {
        playerActions.OnStartHold += StartDetectProfile;
        playerActions.OnEndHold += EndDetectProfile;
        //playerActions.OnTap += TapPerformed;
    }

    private void OnDisable()
    {
        playerActions.OnStartHold -= StartDetectProfile;
        playerActions.OnEndHold -= EndDetectProfile;
        //playerActions.OnTap -= TapPerformed;
    }

    void StartDetectProfile(Vector2 position)
    {
        Ray ray = playerActions.GetScreenToWorldRay();
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

        if (hit2D.collider != null)
        {
            dragActive = true;
            profileTransform = hit2D.collider.transform.parent.GetComponent<Transform>();
            profileStartPosition = profileTransform.position;
            profileCoroutine = StartCoroutine(MoveProfile());
        }
    }
    
    private IEnumerator MoveProfile()
    {
        
        while (true)
        {
            if (profileTransform == null)
            {
                yield return null;
            }
            else
            {
                profileTransform.DOMove(playerActions.PrimaryPosition(), .13f) ;
            }

            yield return null;
        }
    }

    
    void EndDetectProfile(Vector2 position)
    {
        if (dragActive)
        {
            dragActive = false;
            StopCoroutine(MoveProfile());
            DOTween.Kill(this);
            profileTransform.DOMove(profileStartPosition, .2f);
            profileTransform = null;
            
        }
    }
}
