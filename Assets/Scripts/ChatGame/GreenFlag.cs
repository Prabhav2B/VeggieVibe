using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenFlag : MonoBehaviour
{
    public ChatGeneration _chatGeneration { set; private get; }
    private bool heartClicked;
    

    private void Start()
    {
        heartClicked = false;
    }

    private void Update()
    {
        if (_chatGeneration == null)
        {
            return;
        }

        transform.position = transform.position + Vector3.up * (_chatGeneration.ChatSpeed * Time.deltaTime);
    }

    public void HeartClicked()
    {
        heartClicked = true;
        GameManager.instance.FillMeterAmount(10);
        this.GetComponentInChildren<Dummy>().gameObject.SetActive(true);
        
    }
}
