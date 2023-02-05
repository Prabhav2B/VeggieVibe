using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChatGeneration : MonoBehaviour
{

    [SerializeField] private Transform playerChatOrigin;
    [SerializeField] private Transform matchChatOrigin;

    [SerializeField] private Transform chatParent;

    [SerializeField] private List<GameObject> standardPlayerChatBoxes;
    [SerializeField] private List<GameObject> standardMatchChatBoxes;
    private float _chatSpeed;

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
        _chatSpeed = 10f;
        StartChatGeneration();
    }

    void StartChatGeneration()
    {
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

             yield return new WaitForSeconds(1f);
        }
        
        yield return null;
    }

    public enum ChatState
    {
        standard, 
        deepConvo,
        qna,
        ghost
    }
}
