﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using FMODUnity;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //public float iconOffset = 60.0f;
    //public GameObject[] playerIcons = new GameObject[4];

    public GameObject[] characters = new GameObject[4];

    public GameObject pausePanel;
    public Button pauseResumeButton;
    public Button pauseRestartButton;
    public Button pauseMenuButton;

    public GameObject winPanel;
    public Text winText;
    public Button winRestartButton;
    public Button winMenuButton;

    public GameObject BgmManager;

    public AmbienceSound speedUpSound;
    public AmbienceAlert alertSound;

    [HideInInspector] public bool isPaused;
    [HideInInspector] public bool isEnded;

    private EventInstance inGamePause;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            characters[i].SetActive(false);
            //playerIcons[i].SetActive(false);
        }
        for (int i = 0; i < ControllerManager.instance.joinedPlayer; i++)
        {
            characters[ControllerManager.instance.playerCharacterIndex[i]].SetActive(true);
            characters[ControllerManager.instance.playerCharacterIndex[i]].GetComponent<PlayerController>().controllerIndex = ControllerManager.instance.playerControllerIndex[i];
            characters[ControllerManager.instance.playerCharacterIndex[i]].GetComponent<PlayerController>().playerIndex = i;
        }
        pauseResumeButton.onClick.AddListener(PauseGame);
        pauseRestartButton.onClick.AddListener(Restart);
        pauseMenuButton.onClick.AddListener(BackToMenu);

        winRestartButton.onClick.AddListener(Restart);
        winMenuButton.onClick.AddListener(BackToMenu);

        pausePanel.SetActive(false);
        winPanel.SetActive(false);
        BgmManager.SetActive(true); //level bgm enabled

        Physics2D.IgnoreLayerCollision(8, 9);

        //call snapshot pause
        inGamePause = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Pause");


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        if (isEnded)
        {
            return;
        }
    }

    //void IconFollow()
    //{
    //    for (int i = 0; i < 4; i++)
    //    {
    //        playerIcons[i].SetActive(false);
    //    }
    //    for (int i = 0; i < 4; i++)
    //    {
    //        if (characters[i].activeSelf)
    //        {
    //            if (!characters[i].GetComponent<PlayerController>().isDead)
    //            {
    //                playerIcons[characters[i].GetComponent<PlayerController>().playerIndex].SetActive(true);
    //                playerIcons[characters[i].GetComponent<PlayerController>().playerIndex].transform.position = Camera.main.WorldToScreenPoint(characters[i].transform.position) + new Vector3(0, iconOffset, 0);
    //            }
    //        }
    //    }
    //}

    public void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            pausePanel.SetActive(false);
            inGamePause.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
            pausePanel.SetActive(true);
            inGamePause.start();
        }
    }

    void Restart()
    {
        inGamePause.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        speedUpSound.StopSound();
        alertSound.StopSound();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    void BackToMenu()
    {
        Time.timeScale = 1;
        inGamePause.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Destroy(ControllerManager.instance.gameObject);
        speedUpSound.StopSound();
        alertSound.StopSound();
        SceneManager.LoadScene(0);
        //reset parameters
    }

    public void CheckWin()
    {
        int sum = 0;
        int index = 0;
        foreach (var i in characters)
        {
            if (!i.GetComponent<Player>().isDead && i.activeSelf)
            {
                sum++;
                index = i.GetComponent<PlayerController>().playerIndex;
            }
        }
        if(sum == 1)
        {
            Win(index);
        }
    }

    void Win(int playerNum)
    {
        winPanel.SetActive(true);
        BgmManager.SetActive(false); //level bgm disabled
        speedUpSound.StopSound();
        winText.text = "Player" + (playerNum + 1).ToString() + " Win!";
        isEnded = true;
        Time.timeScale = 0;
    }
}
