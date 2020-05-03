using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AmbienceSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string eventPath;

    private EventInstance eventRef;
    private EventInstance eventRef2;
    private float value = 0.0f;

    public GameObject BgmManager;
    void Start()
    {
        eventRef = RuntimeManager.CreateInstance("event:/Ambience/Speed up");
        eventRef2 = RuntimeManager.CreateInstance("event:/Music/Level theme music");

        eventRef.start();
        eventRef2.start();
    }

    void Update()
    {

        float temp;
        eventRef.getParameterByName("Speed", out temp);
        Debug.Log(temp);

        value = (MapCreator.instance.movingSpeed - MapCreator.instance.minMovingSpeed) /
            (MapCreator.instance.maxMovingSpeed - MapCreator.instance.minMovingSpeed);
        eventRef.setParameterByName("Speed", value);
        eventRef2.setParameterByName("Speed", value);

        if (!BgmManager.activeSelf)
        {
            value = 0.0f;
        }//stop playing ambiencesound
    }

    public void StopSound()
    {
        eventRef.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        eventRef2.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
