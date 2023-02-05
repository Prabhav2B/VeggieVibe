using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatGeneration : MonoBehaviour
{
    
    private static readonly Vector3 matchChatPosition = new Vector3(-6f, -10f, 0f);
    private static readonly Vector3 playerChatPosition = new Vector3(6f, -10f, 0f);
    
    //[SerializeField] private GameObject 
    
    

    
    void Update()
    {
        
    }
    
    public enum ChatState
    {
        standard, 
        deepConvo,
        qna,
        ghost
    }
}
