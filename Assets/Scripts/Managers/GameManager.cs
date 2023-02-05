using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private ProfilesManager _profilesManager;
    [SerializeField] private ChatGameManager _chatGameManager;

    #region Events

    public delegate void Match(ProfileBehavior profileBehavior);

    public event Match OnMatch;

    #endregion

    private static readonly Vector3 profilesDock = new Vector3(-6f, 0f, 0f);
    private static readonly Vector3 chatGameDock = new Vector3(6f, 0f, 0f);

    private void OnEnable()
    {
        OnMatch += StartChatGame;
    }

    private void OnDisable()
    {
        OnMatch += StartChatGame;
    }

    void Start()
    {
        //OnMatch(gameObject.AddComponent<ProfileBehavior>());
    }

    void StartChatGame(ProfileBehavior profile)
    {
        _profilesManager.transform.DOMove(profilesDock, 1.5f).SetEase(Ease.InFlash);
        
        //This should be turned off when a match is found!
        _profilesManager.GetComponent<ProfileInteraction>().enabled = false;
        
        _chatGameManager.transform.DOMove(Vector3.zero, 1.5f).SetEase(Ease.InFlash).onComplete = EnableChatGameInteraction;
    }

    private void EnableChatGameInteraction()
    {
        _chatGameManager.GetComponent<ChatGameInteraction>().enabled = true;
    }
}