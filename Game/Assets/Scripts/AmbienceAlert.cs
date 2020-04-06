using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AmbienceAlert : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string eventPath;
    public float minPos;
    public float maxPos;


    private EventInstance eventRef;
    private float value = 0.0f;
    void Start()
    {
        eventRef = RuntimeManager.CreateInstance("event:/Ambience/Dangerous zone");

        eventRef.start();
    }

    void Update()
    {
        if (GameManager.instance.isEnded)
        {
            eventRef.setParameterByName("Border", 0);
            return;
        }
        float minD = 1;
        float minV = 0;
        for (int i = 0; i < GameManager.instance.characters.Length; i++) 
        {
            float v = (GameManager.instance.characters[i].transform.position.y - minPos) / (maxPos - minPos);
            float d = (v > 1 - v) ? 1 - v : v;
            if (d < minD)
            {
                minD = d;
                minV = v;
            }
        }
        value = minV;
        eventRef.setParameterByName("Border", value);
    }
}