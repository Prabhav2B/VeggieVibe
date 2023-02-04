using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private PlayerActions playerActions;

    [SerializeField] private float minimumDistance = 0.2f;
    [SerializeField] private float maximumTime = 1f;
    [SerializeField, Range(0f, 1f)] private float directionThreshold = 0.9f;

    [SerializeField] private GameObject trail;
    
    private Vector2 startPosition;
    private float startTime;

    private Coroutine trailCoroutine;
    
    private Vector2 endPosition;
    private float endTime;
    
    private void OnEnable()
    {
        playerActions.OnStartTouch += SwipeStart;
        playerActions.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        playerActions.OnStartTouch -= SwipeStart;
        playerActions.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
        trail.SetActive(true);
        trail.transform.position = position;

        trailCoroutine = StartCoroutine(Trail());
    }
    
    private void SwipeEnd(Vector2 position, float time)
    {
        trail.SetActive(false);
        StopCoroutine(trailCoroutine);
        trail.transform.position = position;
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private IEnumerator Trail()
    {
        while (true)
        {
            trail.transform.position = playerActions.PrimaryPosition();
            yield return null;
        }
    }

    private void DetectSwipe()
    {
        if (Vector3.Distance(startPosition, endPosition) >= minimumDistance &&
            (endTime - startTime) <= maximumTime)
        {
            //Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            Debug.Log("Swipe Up!");
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            Debug.Log("Swipe Down!");
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            Debug.Log("Swipe Left!");
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            Debug.Log("Swipe Right!");
        }
    }
}
