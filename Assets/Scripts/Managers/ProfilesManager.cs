using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilesManager : MonoBehaviour
{
    public static ProfilesManager instance;
    [SerializeField] GameObject profilePrefab;
    private ProfileBehavior[] _profiles;
    private int layerIndex;
    public GameObject currentProfile;
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

    public void SpawnMoreProfile()
    {
        GameObject newProfile = Instantiate(profilePrefab, transform);
        SetSortingOrder(newProfile.GetComponentsInChildren<SpriteRenderer>());
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
            Debug.LogError("Reject");
        }
        if (dir == GestureBehavior.Direction.right)
        {
            //like swipe
            Debug.LogError("Like");
        }
        if (dir == GestureBehavior.Direction.up)
        {
            Debug.LogError("Superlike");
            //superlike swipe
        }
    }
}
