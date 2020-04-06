using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
public class FootstepSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string eventPath;
    private EventInstance eventRef;

    private float value = 1.0f;
    void Start()
    {

    }

    void Update()
    {
        eventRef = RuntimeManager.CreateInstance("event:/Sound Effects/Footsteps");
        if (GetComponent<Player>().movingDelta == 0)
        {
            eventRef.setParameterByName("Step", 0);
        }
        else
        {
            eventRef.setParameterByName("Step", 1);
        }
    }
}
