using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;


public class ProfilesManager : MonoBehaviour
{
    public static ProfilesManager instance;
    [SerializeField] GameObject profilePrefab;
    [SerializeField] float swipeAwayTime = 2f;
    //private ProfileBehavior[] _profiles;
    //private int layerIndex;
    public GameObject currentProfile;
    int currentSortingMultiplier;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        //layerIndex = 0;
        //_profiles = GetComponentsInChildren<ProfileBehavior>();
        // TestProfileSetup();        
        SpawnMoreProfile();
    }

    //void TestProfileSetup()
    //{
    //    SpriteRenderer[] profileSr;
    //    foreach (var profile in _profiles)
    //    {
    //        profileSr = profile.GetComponentsInChildren<SpriteRenderer>();

    //        foreach (var sr in profileSr)
    //        {
    //            sr.sortingOrder = layerIndex--;
    //        }
    //    }
    //}
   
    void SetSortingOrder(SpriteRenderer[] sprites)
    {
        currentProfile = transform.GetChild(currentSortingMultiplier).gameObject;
        currentSortingMultiplier++;
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].sortingOrder-=50* currentSortingMultiplier;
        }
    }

    public void SwipeAwayDirection(GestureBehavior.Direction dir)
    {
        ProfileGeneration profile = currentProfile.GetComponentInChildren<ProfileGeneration>();
        if(!profile)
        {
            Debug.LogError("No Profiles");
            return;
        }
        if (dir == GestureBehavior.Direction.left)
        {
            //reject swipe
            profile.Dislike();
            profile.transform.DOMove(Vector2.left*10f, swipeAwayTime).SetEase(Ease.OutQuad);
            profile.transform.DORotate(Vector3.forward*10, .1f);
            Debug.LogError("Reject");
        }
        if (dir == GestureBehavior.Direction.right)
        {
            //like swipe
            profile.Like();
            profile.transform.DOMove(Vector2.right*10f, swipeAwayTime).SetEase(Ease.OutQuad);
            profile.transform.DORotate(Vector3.forward*-10, .1f);
            Debug.LogError("Like");
        }
        if (dir == GestureBehavior.Direction.up)
        {
            profile.Superlike();
            profile.transform.DOMove(Vector2.up*20f, swipeAwayTime).SetEase(Ease.OutQuad);
            Debug.LogError("Superlike");
            //superlike swipe
        }
        //StartCoroutine(profile.ProfileDeactivate(swipeAwayTime + 0.3f));
        SpawnMoreProfile();
    }
    void SpawnMoreProfile()
    {
        GameManager.instance.ProfileNumberUpdate();
        GameObject newProfile = Instantiate(profilePrefab, transform);
        SetSortingOrder(newProfile.GetComponentsInChildren<SpriteRenderer>());
    }
}
