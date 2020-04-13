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
    private float value = 0.0f;

    public GameObject BgmManager;
    void Start()
    {
        eventRef = RuntimeManager.CreateInstance("event:/Ambience/Speed up");

        eventRef.start();
    }

    void Update()
    {

        value = (MapCreator.instance.movingSpeed - MapCreator.instance.minMovingSpeed) /
            (MapCreator.instance.maxMovingSpeed - MapCreator.instance.minMovingSpeed);
        eventRef.setParameterByName("Speed", value);

        if (!BgmManager.activeSelf)
        {
            value = 0.0f;
        }//stop playing ambiencesound
    }
}
