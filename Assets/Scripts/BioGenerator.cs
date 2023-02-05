using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BioGenerator : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI jobText;

    public string[] names;
    public string[] jobs;
    // Start is called before the first frame update
    public void UpdateNames()
    {
        nameText.text = names[Random.Range(0,names.Length)];
        jobText.text = jobs[Random.Range(0,jobs.Length)];
    }
}
