using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ProfileGeneration : MonoBehaviour
{
    [SerializeField] SpriteRenderer stalk;
    [SerializeField] SpriteRenderer eyes;
    [SerializeField] SpriteRenderer mouth;
    [SerializeField] SpriteRenderer body;
    [SerializeField] SpriteRenderer bg;

    [SerializeField] Sprite[] stalkOptions;
    [SerializeField] Sprite[] eyesOptions;
    [SerializeField] Sprite[] mouthOptions;
    [SerializeField] Sprite[] bodyOptions;
    [SerializeField] Sprite[] bgOptions;

    [SerializeField] Vector2 randomBodyScaleX;
    [SerializeField] Vector2 randomBodyScaleY;
    [SerializeField] Vector2 randomStalkScaleX;
    [SerializeField] Vector2 randomStalkScaleY;
    [SerializeField] Vector2 randomRotation;

    [SerializeField] Color[] randomStalkColors;   
    [SerializeField] Color[] randomBodyColors;   



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
        if (eyesOptions.Length > 0)
            eyes.sprite = eyesOptions[Random.Range(0, eyesOptions.Length)];
        if (mouthOptions.Length>0)
            mouth.sprite = mouthOptions[Random.Range(0, mouthOptions.Length)];
        if(bodyOptions.Length>0)
            body.sprite = bodyOptions[Random.Range(0, bodyOptions.Length)];
        if (bgOptions.Length > 0)
            bg.sprite = bgOptions[Random.Range(0, bgOptions.Length)];

        body.transform.localScale = new Vector2(Random.Range(randomBodyScaleX.x,randomBodyScaleX.y ),
                                                    Random.Range(randomBodyScaleY.x, randomBodyScaleY.y));

        stalk.transform.localScale = new Vector2(Random.Range(randomStalkScaleX.x, randomStalkScaleX.y),
                                                    Random.Range(randomStalkScaleY.x, randomStalkScaleY.y));

        stalk.transform.eulerAngles = new Vector3(0,0,Random.Range(randomRotation.x, randomRotation.y));

        stalk.color = randomStalkColors[Random.Range(0,randomStalkColors.Length)];
        body.color = randomBodyColors[Random.Range(0, randomBodyColors.Length)];
    }
}
