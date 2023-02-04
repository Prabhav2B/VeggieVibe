using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatBoxes : MonoBehaviour
{
    public bool debugSpawnContent;
    [Range(0,100)]
    [SerializeField] int currentMood;

    [SerializeField] SpriteRenderer currentContent;

    List<Sprite> currentPool;
    [SerializeField] List<Sprite> goodPool;
    [SerializeField] List<Sprite>  badPool;
    [SerializeField] List<Sprite>  questionPool;
    [SerializeField] List<Sprite> answerPool;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentMood>=40)
        {
            currentPool = goodPool;
        }
        else
        {
            currentPool = badPool;
        }

        if(debugSpawnContent)
        {
            debugSpawnContent = false;
            currentContent.sprite = currentPool[Random.Range(0, currentPool.Count)];
        }
    }
}
