using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChatGeneration : MonoBehaviour
{

    [SerializeField] private Transform playerChatOrigin;
    [SerializeField] private Transform matchChatOrigin;

    [SerializeField] private Transform chatParent;

    [SerializeField] private List<GameObject> standardPlayerChatBoxes;
    [SerializeField] private List<GameObject> standardMatchChatBoxes;

    [SerializeField] private int incrementSteps = 10;
    private int currentStep;
    
    private float _chatSpeed;
    private float chatBuffer;
    
    public float ChatSpeed
    {
        get
        {
            return _chatSpeed;
        }
       
    }

    private Coroutine chatGeneratorCoroutine;

    private bool playerOrMatch;
    
    private void Start()
    {
        _chatSpeed = 1f;
        chatBuffer = 2f;
        StartChatGeneration();
    }

    void StartChatGeneration()
    {
        currentStep = 0;
        chatGeneratorCoroutine = StartCoroutine(ChatGenerator());
    }

    IEnumerator ChatGenerator()
    {
        while (true)
        {
            var flip = Random.Range(0, 2);
            playerOrMatch = flip == 0 ? true : false;
            var instantiationTransform = playerOrMatch ? playerChatOrigin : matchChatOrigin;

            var currentPool = playerOrMatch ? standardPlayerChatBoxes : standardMatchChatBoxes;

            var currentChatPrefab = currentPool[Random.Range(0, currentPool.Count)];
            
            
             var go = (GameObject)Instantiate(currentChatPrefab, chatParent);
             go.transform.position = instantiationTransform.position;
             go.GetComponent<ChatBoxes>()._chatGeneration = this;

             var chatBoxSize = go.GetComponentInChildren<Collider2D>().bounds;

             var size = chatBoxSize.size;

             var timeToWait = ((size.y) / ChatSpeed) + (chatBuffer / _chatSpeed) ;

             currentStep++;

             CheckStepIncrement();

             yield return new WaitForSeconds(timeToWait);
        }
        
        yield return null;
    }

    private void CheckStepIncrement()
    {
        if (currentStep > incrementSteps)
        {
            var targetSpeed = _chatSpeed + 1f;
            currentStep = 0;
            incrementSteps += 10;
            var target_buffer = chatBuffer + 0.5; 
            DOTween.To(() => _chatSpeed, x => _chatSpeed = (float) x, targetSpeed, 10f);
            DOTween.To(() => chatBuffer, x => chatBuffer = (float) x, target_buffer, 10f);
        }
    }

    public enum ChatState
    {
        standard, 
        deepConvo,
        qna,
        ghost
    }
}
