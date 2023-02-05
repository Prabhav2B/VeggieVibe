using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class ChatBoxes : MonoBehaviour
{
    [Range(0,100)]
    [SerializeField] int currentMood;

    [SerializeField] SpriteRenderer currentContent;

    List<Sprite> currentPool;
    [SerializeField] List<Sprite> goodPool;
    [SerializeField] List<Sprite>  badPool;
    [SerializeField] List<Sprite>  questionPool;
    [SerializeField] List<Sprite> answerPool;

    public ChatGeneration _chatGeneration { set; private get; }
    
    // Start is called before the first frame update
    void OnEnable()
    {
        if (currentMood >= 40)
        {
            currentPool = goodPool;
        }
        else
        {
            currentPool = badPool;
        }

        currentContent.sprite = currentPool[Random.Range(0, currentPool.Count)];

    }

    private void Update()
    {
        if (_chatGeneration == null)
        {
            return;
        }

        transform.position = transform.position + Vector3.up * (_chatGeneration.ChatSpeed * Time.deltaTime);
    }

}
