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

    public GameObject BgmManager;

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
            if(GameManager.instance.characters[i].activeSelf == false)
            {
                continue;
            }
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

        if (!BgmManager.activeSelf)
        {
            value = 0.0f;
        }//stop playing ambiencesound
        float temp;
        eventRef.getParameterByName("Border", out temp);
        Debug.Log(temp);
    }

    public void StopSound()
    {
        eventRef.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}