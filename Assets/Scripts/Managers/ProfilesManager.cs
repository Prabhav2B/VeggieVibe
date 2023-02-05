using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilesManager : MonoBehaviour
{

    private ProfileBehavior[] _profiles;
    private int layerIndex;
    
    void Start()
    {
        layerIndex = 0;
        _profiles = GetComponentsInChildren<ProfileBehavior>();
        TestProfileSetup();
    }

    void TestProfileSetup()
    {
        SpriteRenderer profileSr;
        foreach (var profile in _profiles)
        {
            profileSr = profile.GetComponentInChildren<SpriteRenderer>();
            profileSr.sortingOrder = layerIndex--;
            profileSr.color = Random.ColorHSV();

        }
    }
}
