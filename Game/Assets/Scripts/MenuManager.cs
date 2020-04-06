﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMODUnity;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public GameObject[] playerIcons = new GameObject[4];

    public Image[] outlines = new Image[4];
    public Sprite[] selectImages = new Sprite[4];

    public Button playButton;
    public Button creditsButton;
    public Button backButton;
    public Button exitButton;
    public Button goButton;
    public Button creditBackButton;

    public GameObject choosePanel;
    public GameObject initialPanel;
    public GameObject creditsPanel;

    private bool[] isPlayerConfirmed = new bool[4];
    private bool[] isCharacterSelected = new bool[4];
    private bool[] isControllerJoined = new bool[8];
    private bool[] playerChooseState = new bool[4];

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        for (int i = 0; i < 4; i++)
        {
            playerIcons[i].SetActive(false);
            isPlayerConfirmed[i] = false;
            isCharacterSelected[i] = false;
            playerChooseState[i] = false;
        }
        for (int i = 0; i < 8; i++)
        {
            isControllerJoined[i] = false;
        }
        playButton.onClick.AddListener(ShowChoosePanel);
        backButton.onClick.AddListener(HideChoosePanel);
        exitButton.onClick.AddListener(ExitGame);
        goButton.onClick.AddListener(GoPlay);
        creditsButton.onClick.AddListener(ShowCreditsPanel);
        creditBackButton.onClick.AddListener(HideCreditsPanel);
        HideChoosePanel();
        HideCreditsPanel();
    }


    void Update()
    {
        if (!choosePanel.activeSelf)
        {
            return;
        }
        DetectController();
        ChooseCharacter();
    }

    void ChooseCharacter()
    {
        if (ControllerManager.instance.playerControllerIndex[0] != 0)
        {
            switch (ControllerManager.instance.playerControllerIndex[0])
            {
                case 1:
                    if (Input.GetAxis("Joystick1 X") == 0)
                    {
                        playerChooseState[0] = false;
                    }
                    if (Input.GetAxis("Joystick1 X") > 0 && !playerChooseState[0] && !isPlayerConfirmed[0])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[0] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[0]++;
                            playerIcons[0].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[0] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick1 X") < 0 && !playerChooseState[0] && !isPlayerConfirmed[0])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[0] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[0]--;
                            playerIcons[0].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[0] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick1Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]])//Y/△
                    {
                        isPlayerConfirmed[0] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].sprite = selectImages[0];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick1Button3) && isPlayerConfirmed[0])//Y/△
                    {
                        isPlayerConfirmed[0] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].gameObject.SetActive(false);
                    }
                    break;
                case 2:
                    if (Input.GetAxis("Joystick2 X") == 0)
                    {
                        playerChooseState[0] = false;
                    }
                    if (Input.GetAxis("Joystick2 X") > 0 && !playerChooseState[0] && !isPlayerConfirmed[0])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[0] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[0]++;
                            playerIcons[0].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[0] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick2 X") < 0 && !playerChooseState[0] && !isPlayerConfirmed[0])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[0] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[0]--;
                            playerIcons[0].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[0] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick2Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]])//Y/△
                    {
                        isPlayerConfirmed[0] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].sprite = selectImages[0];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick2Button3) && isPlayerConfirmed[0])//Y/△
                    {
                        isPlayerConfirmed[0] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].gameObject.SetActive(false);
                    }
                    break;
                case 3:
                    if (Input.GetAxis("Joystick3 X") == 0)
                    {
                        playerChooseState[0] = false;
                    }
                    if (Input.GetAxis("Joystick3 X") > 0 && !playerChooseState[0] && !isPlayerConfirmed[0])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[0] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[0]++;
                            playerIcons[0].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[0] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick3 X") < 0 && !playerChooseState[0] && !isPlayerConfirmed[0])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[0] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[0]--;
                            playerIcons[0].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[0] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick3Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]])//Y/△
                    {
                        isPlayerConfirmed[0] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].sprite = selectImages[0];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick3Button3) && isPlayerConfirmed[0])//Y/△
                    {
                        isPlayerConfirmed[0] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].gameObject.SetActive(false);
                    }
                    break;
                case 4:
                    if (Input.GetAxis("Joystick4 X") == 0)
                    {
                        playerChooseState[0] = false;
                    }
                    if (Input.GetAxis("Joystick4 X") > 0 && !playerChooseState[0] && !isPlayerConfirmed[0])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[0] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[0]++;
                            playerIcons[0].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[0] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick4 X") < 0 && !playerChooseState[0] && !isPlayerConfirmed[0])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[0] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[0]--;
                            playerIcons[0].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[0] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick4Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]])//Y/△
                    {
                        isPlayerConfirmed[0] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].sprite = selectImages[0];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick4Button3) && isPlayerConfirmed[0])//Y/△
                    {
                        isPlayerConfirmed[0] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].gameObject.SetActive(false);
                    }
                    break;
                case 5:
                    if (Input.GetAxis("Joystick5 X") == 0)
                    {
                        playerChooseState[0] = false;
                    }
                    if (Input.GetAxis("Joystick5 X") > 0 && !playerChooseState[0] && !isPlayerConfirmed[0])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[0] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[0]++;
                            playerIcons[0].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[0] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick5 X") < 0 && !playerChooseState[0] && !isPlayerConfirmed[0])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[0] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[0]--;
                            playerIcons[0].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[0] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick5Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]])//Y/△
                    {
                        isPlayerConfirmed[0] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].sprite = selectImages[0];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick5Button3) && isPlayerConfirmed[0])//Y/△
                    {
                        isPlayerConfirmed[0] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].gameObject.SetActive(false);
                    }
                    break;
                case 6:
                    if (Input.GetAxis("Joystick6 X") == 0)
                    {
                        playerChooseState[0] = false;
                    }
                    if (Input.GetAxis("Joystick6 X") > 0 && !playerChooseState[0] && !isPlayerConfirmed[0])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[0] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[0]++;
                            playerIcons[0].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[0] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick6 X") < 0 && !playerChooseState[0] && !isPlayerConfirmed[0])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[0] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[0]--;
                            playerIcons[0].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[0] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick6Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]])//Y/△
                    {
                        isPlayerConfirmed[0] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].sprite = selectImages[0];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick6Button3) && isPlayerConfirmed[0])//Y/△
                    {
                        isPlayerConfirmed[0] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[0]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[0]].gameObject.SetActive(false);
                    }
                    break;
                default: break;
            }
        }
        if (ControllerManager.instance.playerControllerIndex[1] != 0)
        {
            switch (ControllerManager.instance.playerControllerIndex[1])
            {
                case 1:
                    if (Input.GetAxis("Joystick1 X") == 0)
                    {
                        playerChooseState[1] = false;
                    }
                    if (Input.GetAxis("Joystick1 X") > 0 && !playerChooseState[1] && !isPlayerConfirmed[1])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[1] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[1]++;
                            playerIcons[1].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[1] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick1 X") < 0 && !playerChooseState[1] && !isPlayerConfirmed[1])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[1] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[1]--;
                            playerIcons[1].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[1] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick1Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]])//Y/△
                    {
                        isPlayerConfirmed[1] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].sprite = selectImages[1];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick1Button3) && isPlayerConfirmed[1])//Y/△
                    {
                        isPlayerConfirmed[1] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].gameObject.SetActive(false);
                    }
                    break;
                case 2:
                    if (Input.GetAxis("Joystick2 X") == 0)
                    {
                        playerChooseState[1] = false;
                    }
                    if (Input.GetAxis("Joystick2 X") > 0 && !playerChooseState[1] && !isPlayerConfirmed[1])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[1] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[1]++;
                            playerIcons[1].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[1] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick2 X") < 0 && !playerChooseState[1] && !isPlayerConfirmed[1])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[1] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[1]--;
                            playerIcons[1].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[1] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick2Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]])//Y/△
                    {
                        isPlayerConfirmed[1] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].sprite = selectImages[1];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick2Button3) && isPlayerConfirmed[1])//Y/△
                    {
                        isPlayerConfirmed[1] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].gameObject.SetActive(false);
                    }
                    break;
                case 3:
                    if (Input.GetAxis("Joystick3 X") == 0)
                    {
                        playerChooseState[1] = false;
                    }
                    if (Input.GetAxis("Joystick3 X") > 0 && !playerChooseState[1] && !isPlayerConfirmed[1])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[1] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[1]++;
                            playerIcons[1].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[1] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick3 X") < 0 && !playerChooseState[1] && !isPlayerConfirmed[1])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[1] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[1]--;
                            playerIcons[1].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[1] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick3Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]])//Y/△
                    {
                        isPlayerConfirmed[1] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].sprite = selectImages[1];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick3Button3) && isPlayerConfirmed[1])//Y/△
                    {
                        isPlayerConfirmed[1] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].gameObject.SetActive(false);
                    }
                    break;
                case 4:
                    if (Input.GetAxis("Joystick4 X") == 0)
                    {
                        playerChooseState[1] = false;
                    }
                    if (Input.GetAxis("Joystick4 X") > 0 && !playerChooseState[1] && !isPlayerConfirmed[1])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[1] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[1]++;
                            playerIcons[1].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[1] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick4 X") < 0 && !playerChooseState[1] && !isPlayerConfirmed[1])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[1] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[1]--;
                            playerIcons[1].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[1] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick4Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]])//Y/△
                    {
                        isPlayerConfirmed[1] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].sprite = selectImages[1];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick4Button3) && isPlayerConfirmed[1])//Y/△
                    {
                        isPlayerConfirmed[1] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].gameObject.SetActive(false);
                    }
                    break;
                case 5:
                    if (Input.GetAxis("Joystick5 X") == 0)
                    {
                        playerChooseState[1] = false;
                    }
                    if (Input.GetAxis("Joystick5 X") > 0 && !playerChooseState[1] && !isPlayerConfirmed[1])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[1] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[1]++;
                            playerIcons[1].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[1] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick5 X") < 0 && !playerChooseState[1] && !isPlayerConfirmed[1])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[1] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[1]--;
                            playerIcons[1].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[1] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick5Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]])//Y/△
                    {
                        isPlayerConfirmed[1] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].sprite = selectImages[1];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick5Button3) && isPlayerConfirmed[1])//Y/△
                    {
                        isPlayerConfirmed[1] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].gameObject.SetActive(false);
                    }
                    break;
                case 6:
                    if (Input.GetAxis("Joystick6 X") == 0)
                    {
                        playerChooseState[1] = false;
                    }
                    if (Input.GetAxis("Joystick6 X") > 0 && !playerChooseState[1] && !isPlayerConfirmed[1])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[1] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[1]++;
                            playerIcons[1].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[1] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick6 X") < 0 && !playerChooseState[1] && !isPlayerConfirmed[1])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[1] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[1]--;
                            playerIcons[1].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[1] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick6Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]])//Y/△
                    {
                        isPlayerConfirmed[1] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].sprite = selectImages[1];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick6Button3) && isPlayerConfirmed[1])//Y/△
                    {
                        isPlayerConfirmed[1] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[1]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[1]].gameObject.SetActive(false);
                    }
                    break;
                default: break;
            }
        }
        if (ControllerManager.instance.playerControllerIndex[2] != 0)
        {
            switch (ControllerManager.instance.playerControllerIndex[2])
            {
                case 1:
                    if (Input.GetAxis("Joystick1 X") == 0)
                    {
                        playerChooseState[2] = false;
                    }
                    if (Input.GetAxis("Joystick1 X") > 0 && !playerChooseState[2] && !isPlayerConfirmed[2])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[2] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[2]++;
                            playerIcons[2].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[2] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick1 X") < 0 && !playerChooseState[2] && !isPlayerConfirmed[2])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[2] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[2]--;
                            playerIcons[2].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[2] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick1Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]])//Y/△
                    {
                        isPlayerConfirmed[2] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].sprite = selectImages[2];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick1Button3) && isPlayerConfirmed[2])//Y/△
                    {
                        isPlayerConfirmed[2] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].gameObject.SetActive(false);
                    }                    break;
                case 2:
                    if (Input.GetAxis("Joystick2 X") == 0)
                    {
                        playerChooseState[2] = false;
                    }
                    if (Input.GetAxis("Joystick2 X") > 0 && !playerChooseState[2] && !isPlayerConfirmed[2])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[2] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[2]++;
                            playerIcons[2].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[2] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick2 X") < 0 && !playerChooseState[2] && !isPlayerConfirmed[2])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[2] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[2]--;
                            playerIcons[2].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[2] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick2Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]])//Y/△
                    {
                        isPlayerConfirmed[2] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].sprite = selectImages[2];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick2Button3) && isPlayerConfirmed[2])//Y/△
                    {
                        isPlayerConfirmed[2] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].gameObject.SetActive(false);
                    }                    break;
                case 3:
                    if (Input.GetAxis("Joystick3 X") == 0)
                    {
                        playerChooseState[2] = false;
                    }
                    if (Input.GetAxis("Joystick3 X") > 0 && !playerChooseState[2] && !isPlayerConfirmed[2])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[2] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[2]++;
                            playerIcons[2].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[2] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick3 X") < 0 && !playerChooseState[2] && !isPlayerConfirmed[2])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[2] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[2]--;
                            playerIcons[2].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[2] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick3Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]])//Y/△
                    {
                        isPlayerConfirmed[2] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].sprite = selectImages[2];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick3Button3) && isPlayerConfirmed[2])//Y/△
                    {
                        isPlayerConfirmed[2] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].gameObject.SetActive(false);
                    }                    break;
                case 4:
                    if (Input.GetAxis("Joystick4 X") == 0)
                    {
                        playerChooseState[2] = false;
                    }
                    if (Input.GetAxis("Joystick4 X") > 0 && !playerChooseState[2] && !isPlayerConfirmed[2])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[2] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[2]++;
                            playerIcons[2].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[2] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick4 X") < 0 && !playerChooseState[2] && !isPlayerConfirmed[2])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[2] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[2]--;
                            playerIcons[2].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[2] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick4Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]])//Y/△
                    {
                        isPlayerConfirmed[2] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].sprite = selectImages[2];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick4Button3) && isPlayerConfirmed[2])//Y/△
                    {
                        isPlayerConfirmed[2] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].gameObject.SetActive(false);
                    }                    break;
                case 5:
                    if (Input.GetAxis("Joystick5 X") == 0)
                    {
                        playerChooseState[2] = false;
                    }
                    if (Input.GetAxis("Joystick5 X") > 0 && !playerChooseState[2] && !isPlayerConfirmed[2])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[2] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[2]++;
                            playerIcons[2].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[2] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick5 X") < 0 && !playerChooseState[2] && !isPlayerConfirmed[2])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[2] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[2]--;
                            playerIcons[2].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[2] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick5Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]])//Y/△
                    {
                        isPlayerConfirmed[2] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].sprite = selectImages[2];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick5Button3) && isPlayerConfirmed[2])//Y/△
                    {
                        isPlayerConfirmed[2] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].gameObject.SetActive(false);
                    }                    break;
                case 6:
                    if (Input.GetAxis("Joystick6 X") == 0)
                    {
                        playerChooseState[2] = false;
                    }
                    if (Input.GetAxis("Joystick6 X") > 0 && !playerChooseState[2] && !isPlayerConfirmed[2])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[2] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[2]++;
                            playerIcons[2].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[2] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick6 X") < 0 && !playerChooseState[2] && !isPlayerConfirmed[2])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[2] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[2]--;
                            playerIcons[2].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[2] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick6Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]])//Y/△
                    {
                        isPlayerConfirmed[2] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].sprite = selectImages[2];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick6Button3) && isPlayerConfirmed[2])//Y/△
                    {
                        isPlayerConfirmed[2] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[2]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[2]].gameObject.SetActive(false);
                    }                    break;
                default: break;
            }
        }
        if (ControllerManager.instance.playerControllerIndex[3] != 0)
        {
            switch (ControllerManager.instance.playerControllerIndex[3])
            {
                case 1:
                    if (Input.GetAxis("Joystick1 X") == 0)
                    {
                        playerChooseState[3] = false;
                    }
                    if (Input.GetAxis("Joystick1 X") > 0 && !playerChooseState[3] && !isPlayerConfirmed[3])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[3] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[3]++;
                            playerIcons[3].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[3] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick1 X") < 0 && !playerChooseState[3] && !isPlayerConfirmed[3])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[3] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[3]--;
                            playerIcons[3].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[3] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick1Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]])//Y/△
                    {
                        isPlayerConfirmed[3] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].sprite = selectImages[3];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick1Button3) && isPlayerConfirmed[3])//Y/△
                    {
                        isPlayerConfirmed[3] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].gameObject.SetActive(false);
                    }                    break;
                case 2:
                    if (Input.GetAxis("Joystick2 X") == 0)
                    {
                        playerChooseState[3] = false;
                    }
                    if (Input.GetAxis("Joystick2 X") > 0 && !playerChooseState[3] && !isPlayerConfirmed[3])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[3] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[3]++;
                            playerIcons[3].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[3] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick2 X") < 0 && !playerChooseState[3] && !isPlayerConfirmed[3])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[3] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[3]--;
                            playerIcons[3].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[3] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick2Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]])//Y/△
                    {
                        isPlayerConfirmed[3] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].sprite = selectImages[3];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick2Button3) && isPlayerConfirmed[3])//Y/△
                    {
                        isPlayerConfirmed[3] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].gameObject.SetActive(false);
                    }                    break;
                case 3:
                    if (Input.GetAxis("Joystick3 X") == 0)
                    {
                        playerChooseState[3] = false;
                    }
                    if (Input.GetAxis("Joystick3 X") > 0 && !playerChooseState[3] && !isPlayerConfirmed[3])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[3] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[3]++;
                            playerIcons[3].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[3] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick3 X") < 0 && !playerChooseState[3] && !isPlayerConfirmed[3])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[3] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[3]--;
                            playerIcons[3].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[3] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick3Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]])//Y/△
                    {
                        isPlayerConfirmed[3] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].sprite = selectImages[3];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick3Button3) && isPlayerConfirmed[3])//Y/△
                    {
                        isPlayerConfirmed[3] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].gameObject.SetActive(false);
                    }                    break;
                case 4:
                    if (Input.GetAxis("Joystick4 X") == 0)
                    {
                        playerChooseState[3] = false;
                    }
                    if (Input.GetAxis("Joystick4 X") > 0 && !playerChooseState[3] && !isPlayerConfirmed[3])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[3] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[3]++;
                            playerIcons[3].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[3] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick4 X") < 0 && !playerChooseState[3] && !isPlayerConfirmed[3])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[3] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[3]--;
                            playerIcons[3].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[3] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick4Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]])//Y/△
                    {
                        isPlayerConfirmed[3] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].sprite = selectImages[3];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick4Button3) && isPlayerConfirmed[3])//Y/△
                    {
                        isPlayerConfirmed[3] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].gameObject.SetActive(false);
                    }                    break;
                case 5:
                    if (Input.GetAxis("Joystick5 X") == 0)
                    {
                        playerChooseState[3] = false;
                    }
                    if (Input.GetAxis("Joystick5 X") > 0 && !playerChooseState[3] && !isPlayerConfirmed[3])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[3] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[3]++;
                            playerIcons[3].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[3] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick5 X") < 0 && !playerChooseState[3] && !isPlayerConfirmed[3])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[3] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[3]--;
                            playerIcons[3].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[3] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick5Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]])//Y/△
                    {
                        isPlayerConfirmed[3] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].sprite = selectImages[3];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick5Button3) && isPlayerConfirmed[3])//Y/△
                    {
                        isPlayerConfirmed[3] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].gameObject.SetActive(false);
                    }                    break;
                case 6:
                    if (Input.GetAxis("Joystick6 X") == 0)
                    {
                        playerChooseState[3] = false;
                    }
                    if (Input.GetAxis("Joystick6 X") > 0 && !playerChooseState[3] && !isPlayerConfirmed[3])//Right
                    {
                        if (ControllerManager.instance.playerCharacterIndex[3] < 3)
                        {
                            ControllerManager.instance.playerCharacterIndex[3]++;
                            playerIcons[3].GetComponent<RectTransform>().localPosition += new Vector3(300, 0, 0);
                            playerChooseState[3] = true;
                        }
                    }
                    else if (Input.GetAxis("Joystick6 X") < 0 && !playerChooseState[3] && !isPlayerConfirmed[3])//Left
                    {
                        if (ControllerManager.instance.playerCharacterIndex[3] > 0)
                        {
                            ControllerManager.instance.playerCharacterIndex[3]--;
                            playerIcons[3].GetComponent<RectTransform>().localPosition += new Vector3(-300, 0, 0);
                            playerChooseState[3] = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Joystick6Button3) && !isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]])//Y/△
                    {
                        isPlayerConfirmed[3] = true;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]] = true;
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].gameObject.SetActive(true);
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].sprite = selectImages[3];
                    }
                    else if (Input.GetKeyDown(KeyCode.Joystick6Button3) && isPlayerConfirmed[3])//Y/△
                    {
                        isPlayerConfirmed[3] = false;
                        isCharacterSelected[ControllerManager.instance.playerCharacterIndex[3]] = false;
                        outlines[ControllerManager.instance.playerCharacterIndex[3]].gameObject.SetActive(false);
                    }                    break;
                default: break;
            }
        }
    }

    void DetectController()
    {
        if(Input.GetJoystickNames().Length > 0)
        {
            if (((Input.GetJoystickNames()[0].Contains("Xbox") && Input.GetKeyDown(KeyCode.Joystick1Button1)) || (!Input.GetJoystickNames()[0].Contains("Xbox") && Input.GetKeyDown(KeyCode.Joystick1Button2))) && ControllerManager.instance.joinedPlayer < 4 && !isControllerJoined[0])
            {
                //Debug.Log("B/O");
                ControllerManager.instance.playerControllerIndex[ControllerManager.instance.joinedPlayer] = 1;
                playerIcons[ControllerManager.instance.joinedPlayer].SetActive(true);
                isControllerJoined[0] = true;
                ControllerManager.instance.joinedPlayer++;
            }
        }
        if (Input.GetJoystickNames().Length > 1)
        {
            if (((Input.GetJoystickNames()[1].Contains("Xbox") && Input.GetKeyDown(KeyCode.Joystick2Button1)) || (!Input.GetJoystickNames()[1].Contains("Xbox") && Input.GetKeyDown(KeyCode.Joystick2Button2))) && ControllerManager.instance.joinedPlayer < 4 && !isControllerJoined[1])
            {
                //Debug.Log("SR");
                ControllerManager.instance.playerControllerIndex[ControllerManager.instance.joinedPlayer] = 2;
                playerIcons[ControllerManager.instance.joinedPlayer].SetActive(true);
                isControllerJoined[1] = true;
                ControllerManager.instance.joinedPlayer++;
            }
        }
        if (Input.GetJoystickNames().Length > 2)
        {
            if (((Input.GetJoystickNames()[2].Contains("Xbox") && Input.GetKeyDown(KeyCode.Joystick3Button1)) || (!Input.GetJoystickNames()[2].Contains("Xbox") && Input.GetKeyDown(KeyCode.Joystick3Button2))) && ControllerManager.instance.joinedPlayer < 4 && !isControllerJoined[2])
            {
                //Debug.Log("SR");
                ControllerManager.instance.playerControllerIndex[ControllerManager.instance.joinedPlayer] = 3;
                playerIcons[ControllerManager.instance.joinedPlayer].SetActive(true);
                isControllerJoined[2] = true;
                ControllerManager.instance.joinedPlayer++;
            }
        }
        if (Input.GetJoystickNames().Length > 3)
        {
            if (((Input.GetJoystickNames()[3].Contains("Xbox") && Input.GetKeyDown(KeyCode.Joystick4Button1)) || (!Input.GetJoystickNames()[3].Contains("Xbox") && Input.GetKeyDown(KeyCode.Joystick4Button2))) && ControllerManager.instance.joinedPlayer < 4 && !isControllerJoined[3])
            {
                //Debug.Log("SR");
                ControllerManager.instance.playerControllerIndex[ControllerManager.instance.joinedPlayer] = 4;
                playerIcons[ControllerManager.instance.joinedPlayer].SetActive(true);
                isControllerJoined[3] = true;
                ControllerManager.instance.joinedPlayer++;
            }
        }
        if (Input.GetJoystickNames().Length > 4)
        {
            if (((Input.GetJoystickNames()[4].Contains("Xbox") && Input.GetKeyDown(KeyCode.Joystick5Button1)) || (!Input.GetJoystickNames()[4].Contains("Xbox") && Input.GetKeyDown(KeyCode.Joystick5Button2))) && ControllerManager.instance.joinedPlayer < 4 && !isControllerJoined[4])
            {
                //Debug.Log("SR");
                ControllerManager.instance.playerControllerIndex[ControllerManager.instance.joinedPlayer] = 5;
                playerIcons[ControllerManager.instance.joinedPlayer].SetActive(true);
                isControllerJoined[4] = true;
                ControllerManager.instance.joinedPlayer++;
            }
        }
        if (Input.GetJoystickNames().Length > 5)
        {
            if (((Input.GetJoystickNames()[5].Contains("Xbox") && Input.GetKeyDown(KeyCode.Joystick6Button1)) || (!Input.GetJoystickNames()[5].Contains("Xbox") && Input.GetKeyDown(KeyCode.Joystick6Button2))) && ControllerManager.instance.joinedPlayer < 4 && !isControllerJoined[5])
            {
                //Debug.Log("SR");
                ControllerManager.instance.playerControllerIndex[ControllerManager.instance.joinedPlayer] = 6;
                playerIcons[ControllerManager.instance.joinedPlayer].SetActive(true);
                isControllerJoined[5] = true;
                ControllerManager.instance.joinedPlayer++;
            }
        }
    }

    void ShowChoosePanel()
    {
        choosePanel.SetActive(true);
        initialPanel.SetActive(false);
    }

    void HideChoosePanel()
    {
        choosePanel.SetActive(false);
        initialPanel.SetActive(true);
    }

    void ShowCreditsPanel()
    {
        creditsPanel.SetActive(true);
        initialPanel.SetActive(false);
    }

    void HideCreditsPanel()
    {
        creditsPanel.SetActive(false);
        initialPanel.SetActive(true);
    }

    void GoPlay()
    {
        //if (ControllerManager.instance.joinedPlayer < 2)
        //{
        //    return;
        //}
        for (int i = 0; i < ControllerManager.instance.joinedPlayer; i++)
        {
            if (!isPlayerConfirmed[i])
            {
                return;
            }
        }
        SceneManager.LoadScene(1);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}