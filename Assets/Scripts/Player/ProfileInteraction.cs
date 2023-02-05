using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;

public class ProfileInteraction : MonoBehaviour
{
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] private GestureBehavior playerGestures;

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
        playerGestures.OnSwipe += SwipeAway;
    }

    private void OnDisable()
    {
        playerActions.OnStartHold -= StartDetectProfile;
        playerActions.OnEndHold -= EndDetectProfile;
        playerGestures.OnSwipe -= SwipeAway;
        //playerActions.OnTap -= TapPerformed;
    }

    void StartDetectProfile(Vector2 position)
    {
        if (!GameManager.instance.startSwiping) return;

        Ray ray = playerActions.GetScreenToWorldRay();
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
        Transform currentProf = ProfilesManager.instance.currentProfile.transform;
        if (hit2D.collider != null)
        {
            dragActive = true;
            profileTransform = currentProf;
            //profileTransform = hit2D.collider.transform.parent.GetComponent<Transform>();
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
            if (CheckIfNeedsToBeSwiped(position)) return;

            StopCoroutine(MoveProfile());
            DOTween.Kill(this);
            profileTransform.DOMove(profileStartPosition, .2f);
            profileTransform = null;            
        }
    }

    bool CheckIfNeedsToBeSwiped(Vector2 position)
    {        
        if(position.x > 2.5f)
        {
            SwipeAway(GestureBehavior.Direction.right);
            return true;
        }
        if (position.x < -2.5f)
        {
            SwipeAway(GestureBehavior.Direction.left);
            return true;
        }
        if (position.y > 3.5f)
        {
            SwipeAway(GestureBehavior.Direction.up);
            return true;
        }
        //return to center
        //Debug.LogError("Return to Center");
        return false;
    }

    void SwipeAway(GestureBehavior.Direction dir)
    {
        if (!GameManager.instance.startSwiping) return;
        // create more profiles
        ProfilesManager.instance.SwipeAwayDirection(dir);
    }
}
