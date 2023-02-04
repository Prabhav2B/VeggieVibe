using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class ProfileGeneration : MonoBehaviour
{
    [SerializeField] SpriteRenderer stalk;
    [SerializeField] SpriteRenderer face;
    [SerializeField] SpriteRenderer body;

    [SerializeField] Sprite[] stalkOptions;
    [SerializeField] Sprite[] faceOptions;
    [SerializeField] Sprite[] bodyOptions;


    void Start()
    {
        
    }

    private void OnEnable()
    {
        InitializeProfile();
    }
    

    void InitializeProfile()
    {
        if(stalkOptions.Length>0)
            stalk.sprite = stalkOptions[Random.Range(0, stalkOptions.Length)];
        if(faceOptions.Length>0)
            face.sprite = faceOptions[Random.Range(0, faceOptions.Length)];
        if(bodyOptions.Length>0)
            body.sprite = bodyOptions[Random.Range(0, bodyOptions.Length)];
    }
}
