using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenFlag : MonoBehaviour
{
    public ChatGeneration _chatGeneration { set; private get; }

    private void OnEnable()
    {
        throw new NotImplementedException();
    }

    private void OnDestroy()
    {
        throw new NotImplementedException();
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
