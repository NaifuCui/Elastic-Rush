using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using FMODUnity;

public class ButtonSounds : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Enter");
        RuntimeManager.PlayOneShot("event:/Interface/Select");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Exit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Down");
        RuntimeManager.PlayOneShot("event:/Interface/Confirm");
    }
}
