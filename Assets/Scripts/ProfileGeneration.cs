using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ProfileGeneration : MonoBehaviour
{
    [SerializeField] SpriteRenderer stalk;
    [SerializeField] SpriteRenderer face;
    [SerializeField] SpriteRenderer body;

    [SerializeField] Sprite[] stalkOptions;
    [SerializeField] Sprite[] faceOptions;
    [SerializeField] Sprite[] bodyOptions;

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
        if(faceOptions.Length>0)
            face.sprite = faceOptions[Random.Range(0, faceOptions.Length)];
        if(bodyOptions.Length>0)
            body.sprite = bodyOptions[Random.Range(0, bodyOptions.Length)];

        body.transform.localScale = new Vector2(Random.Range(randomBodyScaleX.x,randomBodyScaleX.y ),
                                                    Random.Range(randomBodyScaleY.x, randomBodyScaleY.y));

        stalk.transform.localScale = new Vector2(Random.Range(randomStalkScaleX.x, randomStalkScaleX.y),
                                                    Random.Range(randomStalkScaleY.x, randomStalkScaleY.y));

        stalk.transform.eulerAngles = new Vector3(0,0,Random.Range(randomRotation.x, randomRotation.y));

        stalk.color = randomStalkColors[Random.Range(0,randomStalkColors.Length)];
        body.color = randomBodyColors[Random.Range(0, randomBodyColors.Length)];
    }
}
