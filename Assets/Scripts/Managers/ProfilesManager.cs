using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;


public class ProfilesManager : MonoBehaviour
{
    public static ProfilesManager instance;
    [SerializeField] GameObject profilePrefab;
    private ProfileBehavior[] _profiles;
    private int layerIndex;
    public GameObject currentProfile;
    GameObject oldProfile;
    int currentSortingMultiplier;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        layerIndex = 0;
        //_profiles = GetComponentsInChildren<ProfileBehavior>();
        // TestProfileSetup();        
        SpawnMoreProfile();
    }

    void TestProfileSetup()
    {
        SpriteRenderer[] profileSr;
        foreach (var profile in _profiles)
        {
            profileSr = profile.GetComponentsInChildren<SpriteRenderer>();

            foreach (var sr in profileSr)
            {
                sr.sortingOrder = layerIndex--;
            }
        }
    }
   
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
        if(dir == GestureBehavior.Direction.left)
        {
            //reject swipe
            currentProfile.transform.DOMove(Vector2.left*10f, .5f);
            Debug.LogError("Reject");
        }
        if (dir == GestureBehavior.Direction.right)
        {
            currentProfile.transform.DOMove(Vector2.right*10f, .5f);
            //like swipe
            Debug.LogError("Like");
        }
        if (dir == GestureBehavior.Direction.up)
        {
            currentProfile.transform.DOMove(Vector2.up*10f, .5f);
            Debug.LogError("Superlike");
            //superlike swipe
        }

        oldProfile = currentProfile;
        SpawnMoreProfile();
        Invoke(nameof(CreateNewProfileWithDelay), 0.5f);
    }

    void CreateNewProfileWithDelay()
    {
        oldProfile.SetActive(false);        
    }
    void SpawnMoreProfile()
    {
        GameObject newProfile = Instantiate(profilePrefab, transform);
        SetSortingOrder(newProfile.GetComponentsInChildren<SpriteRenderer>());
    }
}
