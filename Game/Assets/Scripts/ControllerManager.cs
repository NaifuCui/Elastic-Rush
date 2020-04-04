using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public static ControllerManager instance;

    public int[] playerControllerIndex = new int[4];
    public int[] playerCharacterIndex = new int[4];

    [HideInInspector] public int joinedPlayer;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            for (int i = 0; i < 4; i++)
            {
                playerControllerIndex[i] = 0;
                playerCharacterIndex[i] = 0;
            }
            joinedPlayer = 0;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
