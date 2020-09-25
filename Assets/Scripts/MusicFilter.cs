using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFilter : MonoBehaviour
{
    public AudioLowPassFilter filter;

    void Start()
    {
        filter.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Spawner.isPause)
        {
            filter.enabled = true;
        }
        else filter.enabled = false;
    }
}
