using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(1, 6)]
    public int controllerIndex = 1;
    public int playerIndex = 0;

    private Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (GameManager.instance.isEnded)
        {
            return;
        }
        switch (controllerIndex)
        {
            case 1: Contoller1KeyMapping(); break;
            case 2: Contoller2KeyMapping(); break;
            case 3: Contoller3KeyMapping(); break;
            case 4: Contoller4KeyMapping(); break;
            case 5: Contoller5KeyMapping(); break;
            case 6: Contoller6KeyMapping(); break;
            default: break;
        }
    }



    void Contoller1KeyMapping()
    {
        if (Input.GetJoystickNames().Length < 1)
        {
            return;
        }
        if (Input.GetJoystickNames()[0].Contains("Xbox"))
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                //Debug.Log("A/X");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                //Debug.Log("B/O");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            {
                //Debug.Log("X/□");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button3))
            {
                //Debug.Log("Y/△");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button4))
            {
                player.Rush();
                //Debug.Log("Left Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button5))
            {
                player.UseWeapon();
                //Debug.Log("Right Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button6))
            {
                //Debug.Log("View");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button7))
            {
                GameManager.instance.PauseGame();
                //Debug.Log("Menu");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button8))
            {
                //Debug.Log("L");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button9))
            {
                //Debug.Log("R");
            }
            if (Input.GetAxis("Joystick1 X") != 0)
            {
                //Debug.Log("LeftStickHorizontal 2: " + Input.GetAxis("Joystick1 X"));
            }
            player.Move(Input.GetAxis("Joystick1 X"));
            if (Input.GetAxis("Joystick1 Y") != 0)
            {
                //Debug.Log("LeftStickVertical 2: " + Input.GetAxis("Joystick1 Y"));
            }
            if (Input.GetAxis("Joystick1 4th") != 0)
            {
                //Debug.Log("RightStickHorizontal 2: " + Input.GetAxis("Joystick1 4th"));
            }
            if (Input.GetAxis("Joystick1 5th") != 0)
            {
                //Debug.Log("RightStickVertical 2: " + Input.GetAxis("Joystick1 5th"));
            }
            player.LookAt(Input.GetAxis("Joystick1 5th"), Input.GetAxis("Joystick1 4th"));
            if (Input.GetAxis("Joystick1 6th") != 0)
            {
                //Debug.Log("Right/Left 2: " + Input.GetAxis("Joystick1 6th"));
            }
            if (Input.GetAxis("Joystick1 7th") != 0)
            {
                //Debug.Log("Up/Down 2: " + Input.GetAxis("Joystick1 7th"));
            }
            if (Input.GetAxis("Joystick1 9th") != 0)
            {
                //Debug.Log("Left Trigger 2: " + Input.GetAxis("Joystick1 9th"));
            }
            if (Input.GetAxis("Joystick1 10th") != 0)
            {
                //Debug.Log("Right Trigger 2: " + Input.GetAxis("Joystick1 10th"));
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                //Debug.Log("A/X");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            {
                //Debug.Log("B/O");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                //Debug.Log("X/□");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button3))
            {
                //Debug.Log("Y/△");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button4))
            {
                player.Rush();
                //Debug.Log("Left Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button5))
            {
                player.UseWeapon();
                //Debug.Log("Right Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button6))
            {
                //Debug.Log("Left Trigger");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button7))
            {
                //Debug.Log("Right Trigger");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button8))
            {
                //Debug.Log("View");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button9))
            {
                GameManager.instance.PauseGame();
                //Debug.Log("Menu");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button10))
            {
                //Debug.Log("L");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button11))
            {
                //Debug.Log("R");
            }
            if (Input.GetAxis("Joystick1 X") != 0)
            {
                //Debug.Log("LeftStickHorizontal 2: " + Input.GetAxis("Joystick1 X"));
            }
            player.Move(Input.GetAxis("Joystick1 X"));
            if (Input.GetAxis("Joystick1 Y") != 0)
            {
                //Debug.Log("LeftStickVertical 2: " + Input.GetAxis("Joystick1 Y"));
            }
            if (Input.GetAxis("Joystick1 3rd") != 0)
            {
                //Debug.Log("RightStickHorizontal 2: " + Input.GetAxis("Joystick1 3rd"));
            }
            if (Input.GetAxis("Joystick1 6th") != 0)
            {
                //Debug.Log("RightStickVertical 2: " + Input.GetAxis("Joystick1 6th"));
            }
            player.LookAt(Input.GetAxis("Joystick1 6th"), Input.GetAxis("Joystick1 3rd"));
            if (Input.GetAxis("Joystick1 7th") != 0)
            {
                //Debug.Log("Right/Left 2: " + Input.GetAxis("Joystick1 7th"));
            }
            if (Input.GetAxis("Joystick1 8th") != 0)
            {
                //Debug.Log("Up/Down 2: " + Input.GetAxis("Joystick1 8th"));
            }
            if (Input.GetAxis("Joystick1 4th") != -1)//(default -1, range from -1 to 1)
            {
                //Debug.Log("Left Trigger 2: " + Input.GetAxis("Joystick1 4th"));
            }
            if (Input.GetAxis("Joystick1 5th") != -1)//(default -1, range from -1 to 1)
            {
                //Debug.Log("Right Trigger 2: " + Input.GetAxis("Joystick1 5th"));
            }
        }
    }

    void Contoller2KeyMapping()
    {
        if (Input.GetJoystickNames().Length < 2)
        {
            return;
        }
        if (Input.GetJoystickNames()[1].Contains("Xbox"))
        {
            if (Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
                //Debug.Log("A/X");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button1))
            {
                //Debug.Log("B/O");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button2))
            {
                //Debug.Log("X/□");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button3))
            {
                //Debug.Log("Y/△");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button4))
            {
                player.Rush();
                //Debug.Log("Left Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button5))
            {
                player.UseWeapon();
                //Debug.Log("Right Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button6))
            {
                //Debug.Log("View");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button7))
            {
                GameManager.instance.PauseGame();
                //Debug.Log("Menu");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button8))
            {
                //Debug.Log("L");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button9))
            {
                //Debug.Log("R");
            }
            if (Input.GetAxis("Joystick2 X") != 0)
            {
                //Debug.Log("LeftStickHorizontal 2: " + Input.GetAxis("Joystick2 X"));
            }
            player.Move(Input.GetAxis("Joystick2 X"));
            if (Input.GetAxis("Joystick2 Y") != 0)
            {
                //Debug.Log("LeftStickVertical 2: " + Input.GetAxis("Joystick2 Y"));
            }
            if (Input.GetAxis("Joystick2 4th") != 0)
            {
                //Debug.Log("RightStickHorizontal 2: " + Input.GetAxis("Joystick2 4th"));
            }
            if (Input.GetAxis("Joystick2 5th") != 0)
            {
                //Debug.Log("RightStickVertical 2: " + Input.GetAxis("Joystick2 5th"));
            }
            player.LookAt(Input.GetAxis("Joystick2 5th"), Input.GetAxis("Joystick2 4th"));
            if (Input.GetAxis("Joystick2 6th") != 0)
            {
                //Debug.Log("Right/Left 2: " + Input.GetAxis("Joystick2 6th"));
            }
            if (Input.GetAxis("Joystick2 7th") != 0)
            {
                //Debug.Log("Up/Down 2: " + Input.GetAxis("Joystick2 7th"));
            }
            if (Input.GetAxis("Joystick2 9th") != 0)
            {
                //Debug.Log("Left Trigger 2: " + Input.GetAxis("Joystick2 9th"));
            }
            if (Input.GetAxis("Joystick2 10th") != 0)
            {
                //Debug.Log("Right Trigger 2: " + Input.GetAxis("Joystick2 10th"));
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Joystick2Button1))
            {
                //Debug.Log("A/X");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button2))
            {
                //Debug.Log("B/O");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
                //Debug.Log("X/□");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button3))
            {
                //Debug.Log("Y/△");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button4))
            {
                player.Rush();
                //Debug.Log("Left Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button5))
            {
                player.UseWeapon();
                //Debug.Log("Right Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button6))
            {
                //Debug.Log("Left Trigger");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button7))
            {
                //Debug.Log("Right Trigger");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button8))
            {
                //Debug.Log("View");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button9))
            {
                GameManager.instance.PauseGame();
                //Debug.Log("Menu");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button10))
            {
                //Debug.Log("L");
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button11))
            {
                //Debug.Log("R");
            }
            if (Input.GetAxis("Joystick2 X") != 0)
            {
                //Debug.Log("LeftStickHorizontal 2: " + Input.GetAxis("Joystick2 X"));
            }
            player.Move(Input.GetAxis("Joystick2 X"));
            if (Input.GetAxis("Joystick2 Y") != 0)
            {
                //Debug.Log("LeftStickVertical 2: " + Input.GetAxis("Joystick2 Y"));
            }
            if (Input.GetAxis("Joystick2 3rd") != 0)
            {
                //Debug.Log("RightStickHorizontal 2: " + Input.GetAxis("Joystick2 3rd"));
            }
            if (Input.GetAxis("Joystick2 6th") != 0)
            {
                //Debug.Log("RightStickVertical 2: " + Input.GetAxis("Joystick2 6th"));
            }
            player.LookAt(Input.GetAxis("Joystick2 6th"), Input.GetAxis("Joystick2 3rd"));
            if (Input.GetAxis("Joystick2 7th") != 0)
            {
                //Debug.Log("Right/Left 2: " + Input.GetAxis("Joystick2 7th"));
            }
            if (Input.GetAxis("Joystick2 8th") != 0)
            {
                //Debug.Log("Up/Down 2: " + Input.GetAxis("Joystick2 8th"));
            }
            if (Input.GetAxis("Joystick2 4th") != -1)//(default -1, range from -1 to 1)
            {
                //Debug.Log("Left Trigger 2: " + Input.GetAxis("Joystick2 4th"));
            }
            if (Input.GetAxis("Joystick2 5th") != -1)//(default -1, range from -1 to 1)
            {
                //Debug.Log("Right Trigger 2: " + Input.GetAxis("Joystick2 5th"));
            }
        }
    }

    void Contoller3KeyMapping()
    {
        if (Input.GetJoystickNames().Length < 3)
        {
            return;
        }
        if (Input.GetJoystickNames()[2].Contains("Xbox"))
        {
            if (Input.GetKeyDown(KeyCode.Joystick3Button0))
            {
                //Debug.Log("A/X");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button1))
            {
                //Debug.Log("B/O");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button2))
            {
                //Debug.Log("X/□");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button3))
            {
                //Debug.Log("Y/△");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button4))
            {
                player.Rush();
                //Debug.Log("Left Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button5))
            {
                player.UseWeapon();
                //Debug.Log("Right Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button6))
            {
                //Debug.Log("View");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button7))
            {
                GameManager.instance.PauseGame();
                //Debug.Log("Menu");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button8))
            {
                //Debug.Log("L");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button9))
            {
                //Debug.Log("R");
            }
            if (Input.GetAxis("Joystick3 X") != 0)
            {
                //Debug.Log("LeftStickHorizontal 2: " + Input.GetAxis("Joystick3 X"));
            }
            player.Move(Input.GetAxis("Joystick3 X"));
            if (Input.GetAxis("Joystick3 Y") != 0)
            {
                //Debug.Log("LeftStickVertical 2: " + Input.GetAxis("Joystick3 Y"));
            }
            if (Input.GetAxis("Joystick3 4th") != 0)
            {
                //Debug.Log("RightStickHorizontal 2: " + Input.GetAxis("Joystick3 4th"));
            }
            if (Input.GetAxis("Joystick3 5th") != 0)
            {
                //Debug.Log("RightStickVertical 2: " + Input.GetAxis("Joystick3 5th"));
            }
            player.LookAt(Input.GetAxis("Joystick3 5th"), Input.GetAxis("Joystick3 4th"));
            if (Input.GetAxis("Joystick3 6th") != 0)
            {
                //Debug.Log("Right/Left 2: " + Input.GetAxis("Joystick3 6th"));
            }
            if (Input.GetAxis("Joystick3 7th") != 0)
            {
                //Debug.Log("Up/Down 2: " + Input.GetAxis("Joystick3 7th"));
            }
            if (Input.GetAxis("Joystick3 9th") != 0)
            {
                //Debug.Log("Left Trigger 2: " + Input.GetAxis("Joystick3 9th"));
            }
            if (Input.GetAxis("Joystick3 10th") != 0)
            {
                //Debug.Log("Right Trigger 2: " + Input.GetAxis("Joystick3 10th"));
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Joystick3Button1))
            {
                //Debug.Log("A/X");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button2))
            {
                //Debug.Log("B/O");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button0))
            {
                //Debug.Log("X/□");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button3))
            {
                //Debug.Log("Y/△");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button4))
            {
                player.Rush();
                //Debug.Log("Left Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button5))
            {
                player.UseWeapon();
                //Debug.Log("Right Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button6))
            {
                //Debug.Log("Left Trigger");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button7))
            {
                //Debug.Log("Right Trigger");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button8))
            {
                //Debug.Log("View");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button9))
            {
                GameManager.instance.PauseGame();
                //Debug.Log("Menu");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button10))
            {
                //Debug.Log("L");
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button11))
            {
                //Debug.Log("R");
            }
            if (Input.GetAxis("Joystick3 X") != 0)
            {
                //Debug.Log("LeftStickHorizontal 2: " + Input.GetAxis("Joystick3 X"));
            }
            player.Move(Input.GetAxis("Joystick3 X"));
            if (Input.GetAxis("Joystick3 Y") != 0)
            {
                //Debug.Log("LeftStickVertical 2: " + Input.GetAxis("Joystick3 Y"));
            }
            if (Input.GetAxis("Joystick3 3rd") != 0)
            {
                //Debug.Log("RightStickHorizontal 2: " + Input.GetAxis("Joystick3 3rd"));
            }
            if (Input.GetAxis("Joystick3 6th") != 0)
            {
                //Debug.Log("RightStickVertical 2: " + Input.GetAxis("Joystick3 6th"));
            }
            player.LookAt(Input.GetAxis("Joystick3 6th"), Input.GetAxis("Joystick3 3rd"));
            if (Input.GetAxis("Joystick3 7th") != 0)
            {
                //Debug.Log("Right/Left 2: " + Input.GetAxis("Joystick3 7th"));
            }
            if (Input.GetAxis("Joystick3 8th") != 0)
            {
                //Debug.Log("Up/Down 2: " + Input.GetAxis("Joystick3 8th"));
            }
            if (Input.GetAxis("Joystick3 4th") != -1)//(default -1, range from -1 to 1)
            {
                //Debug.Log("Left Trigger 2: " + Input.GetAxis("Joystick3 4th"));
            }
            if (Input.GetAxis("Joystick3 5th") != -1)//(default -1, range from -1 to 1)
            {
                //Debug.Log("Right Trigger 2: " + Input.GetAxis("Joystick3 5th"));
            }
        }
    }

    void Contoller4KeyMapping()
    {
        if (Input.GetJoystickNames().Length < 4)
        {
            return;
        }
        if (Input.GetJoystickNames()[3].Contains("Xbox"))
        {
            if (Input.GetKeyDown(KeyCode.Joystick4Button0))
            {
                //Debug.Log("A/X");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button1))
            {
                //Debug.Log("B/O");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button2))
            {
                //Debug.Log("X/□");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button3))
            {
                //Debug.Log("Y/△");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button4))
            {
                player.Rush();
                //Debug.Log("Left Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button5))
            {
                player.UseWeapon();
                //Debug.Log("Right Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button6))
            {
                //Debug.Log("View");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button7))
            {
                GameManager.instance.PauseGame();
                //Debug.Log("Menu");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button8))
            {
                //Debug.Log("L");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button9))
            {
                //Debug.Log("R");
            }
            if (Input.GetAxis("Joystick4 X") != 0)
            {
                //Debug.Log("LeftStickHorizontal 2: " + Input.GetAxis("Joystick4 X"));
            }
            player.Move(Input.GetAxis("Joystick4 X"));
            if (Input.GetAxis("Joystick4 Y") != 0)
            {
                //Debug.Log("LeftStickVertical 2: " + Input.GetAxis("Joystick4 Y"));
            }
            if (Input.GetAxis("Joystick4 4th") != 0)
            {
                //Debug.Log("RightStickHorizontal 2: " + Input.GetAxis("Joystick4 4th"));
            }
            if (Input.GetAxis("Joystick4 5th") != 0)
            {
                //Debug.Log("RightStickVertical 2: " + Input.GetAxis("Joystick4 5th"));
            }
            player.LookAt(Input.GetAxis("Joystick4 5th"), Input.GetAxis("Joystick4 4th"));
            if (Input.GetAxis("Joystick4 6th") != 0)
            {
                //Debug.Log("Right/Left 2: " + Input.GetAxis("Joystick4 6th"));
            }
            if (Input.GetAxis("Joystick4 7th") != 0)
            {
                //Debug.Log("Up/Down 2: " + Input.GetAxis("Joystick4 7th"));
            }
            if (Input.GetAxis("Joystick4 9th") != 0)
            {
                //Debug.Log("Left Trigger 2: " + Input.GetAxis("Joystick4 9th"));
            }
            if (Input.GetAxis("Joystick4 10th") != 0)
            {
                //Debug.Log("Right Trigger 2: " + Input.GetAxis("Joystick4 10th"));
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Joystick4Button1))
            {
                //Debug.Log("A/X");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button2))
            {
                //Debug.Log("B/O");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button0))
            {
                //Debug.Log("X/□");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button3))
            {
                //Debug.Log("Y/△");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button4))
            {
                player.Rush();
                //Debug.Log("Left Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button5))
            {
                player.UseWeapon();
                //Debug.Log("Right Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button6))
            {
                //Debug.Log("Left Trigger");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button7))
            {
                //Debug.Log("Right Trigger");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button8))
            {
                //Debug.Log("View");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button9))
            {
                GameManager.instance.PauseGame();
                //Debug.Log("Menu");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button10))
            {
                //Debug.Log("L");
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button11))
            {
                //Debug.Log("R");
            }
            if (Input.GetAxis("Joystick4 X") != 0)
            {
                //Debug.Log("LeftStickHorizontal 2: " + Input.GetAxis("Joystick4 X"));
            }
            player.Move(Input.GetAxis("Joystick4 X"));
            if (Input.GetAxis("Joystick4 Y") != 0)
            {
                //Debug.Log("LeftStickVertical 2: " + Input.GetAxis("Joystick4 Y"));
            }
            if (Input.GetAxis("Joystick4 3rd") != 0)
            {
                //Debug.Log("RightStickHorizontal 2: " + Input.GetAxis("Joystick4 3rd"));
            }
            if (Input.GetAxis("Joystick4 6th") != 0)
            {
                //Debug.Log("RightStickVertical 2: " + Input.GetAxis("Joystick4 6th"));
            }
            player.LookAt(Input.GetAxis("Joystick4 6th"), Input.GetAxis("Joystick4 3rd"));
            if (Input.GetAxis("Joystick4 7th") != 0)
            {
                //Debug.Log("Right/Left 2: " + Input.GetAxis("Joystick4 7th"));
            }
            if (Input.GetAxis("Joystick4 8th") != 0)
            {
                //Debug.Log("Up/Down 2: " + Input.GetAxis("Joystick4 8th"));
            }
            if (Input.GetAxis("Joystick4 4th") != -1)//(default -1, range from -1 to 1)
            {
                //Debug.Log("Left Trigger 2: " + Input.GetAxis("Joystick4 4th"));
            }
            if (Input.GetAxis("Joystick4 5th") != -1)//(default -1, range from -1 to 1)
            {
                //Debug.Log("Right Trigger 2: " + Input.GetAxis("Joystick4 5th"));
            }
        }
    }

    void Contoller5KeyMapping()
    {
        if (Input.GetJoystickNames().Length < 5)
        {
            return;
        }
        if (Input.GetJoystickNames()[4].Contains("Xbox"))
        {
            if (Input.GetKeyDown(KeyCode.Joystick5Button0))
            {
                //Debug.Log("A/X");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button1))
            {
                //Debug.Log("B/O");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button2))
            {
                //Debug.Log("X/□");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button3))
            {
                //Debug.Log("Y/△");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button4))
            {
                player.Rush();
                //Debug.Log("Left Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button5))
            {
                player.UseWeapon();
                //Debug.Log("Right Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button6))
            {
                //Debug.Log("View");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button7))
            {
                GameManager.instance.PauseGame();
                //Debug.Log("Menu");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button8))
            {
                //Debug.Log("L");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button9))
            {
                //Debug.Log("R");
            }
            if (Input.GetAxis("Joystick5 X") != 0)
            {
                //Debug.Log("LeftStickHorizontal 2: " + Input.GetAxis("Joystick5 X"));
            }
            player.Move(Input.GetAxis("Joystick5 X"));
            if (Input.GetAxis("Joystick5 Y") != 0)
            {
                //Debug.Log("LeftStickVertical 2: " + Input.GetAxis("Joystick5 Y"));
            }
            if (Input.GetAxis("Joystick5 4th") != 0)
            {
                //Debug.Log("RightStickHorizontal 2: " + Input.GetAxis("Joystick5 4th"));
            }
            if (Input.GetAxis("Joystick5 5th") != 0)
            {
                //Debug.Log("RightStickVertical 2: " + Input.GetAxis("Joystick5 5th"));
            }
            player.LookAt(Input.GetAxis("Joystick5 5th"), Input.GetAxis("Joystick5 4th"));
            if (Input.GetAxis("Joystick5 6th") != 0)
            {
                //Debug.Log("Right/Left 2: " + Input.GetAxis("Joystick5 6th"));
            }
            if (Input.GetAxis("Joystick5 7th") != 0)
            {
                //Debug.Log("Up/Down 2: " + Input.GetAxis("Joystick5 7th"));
            }
            if (Input.GetAxis("Joystick5 9th") != 0)
            {
                //Debug.Log("Left Trigger 2: " + Input.GetAxis("Joystick5 9th"));
            }
            if (Input.GetAxis("Joystick5 10th") != 0)
            {
                //Debug.Log("Right Trigger 2: " + Input.GetAxis("Joystick5 10th"));
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Joystick5Button1))
            {
                //Debug.Log("A/X");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button2))
            {
                //Debug.Log("B/O");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button0))
            {
                //Debug.Log("X/□");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button3))
            {
                //Debug.Log("Y/△");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button4))
            {
                player.Rush();
                //Debug.Log("Left Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button5))
            {
                player.UseWeapon();
                //Debug.Log("Right Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button6))
            {
                //Debug.Log("Left Trigger");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button7))
            {
                //Debug.Log("Right Trigger");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button8))
            {
                //Debug.Log("View");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button9))
            {
                GameManager.instance.PauseGame();
                //Debug.Log("Menu");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button10))
            {
                //Debug.Log("L");
            }
            if (Input.GetKeyDown(KeyCode.Joystick5Button11))
            {
                //Debug.Log("R");
            }
            if (Input.GetAxis("Joystick5 X") != 0)
            {
                //Debug.Log("LeftStickHorizontal 2: " + Input.GetAxis("Joystick5 X"));
            }
            player.Move(Input.GetAxis("Joystick5 X"));
            if (Input.GetAxis("Joystick5 Y") != 0)
            {
                //Debug.Log("LeftStickVertical 2: " + Input.GetAxis("Joystick5 Y"));
            }
            if (Input.GetAxis("Joystick5 3rd") != 0)
            {
                //Debug.Log("RightStickHorizontal 2: " + Input.GetAxis("Joystick5 3rd"));
            }
            if (Input.GetAxis("Joystick5 6th") != 0)
            {
                //Debug.Log("RightStickVertical 2: " + Input.GetAxis("Joystick5 6th"));
            }
            player.LookAt(Input.GetAxis("Joystick5 6th"), Input.GetAxis("Joystick5 3rd"));
            if (Input.GetAxis("Joystick5 7th") != 0)
            {
                //Debug.Log("Right/Left 2: " + Input.GetAxis("Joystick5 7th"));
            }
            if (Input.GetAxis("Joystick5 8th") != 0)
            {
                //Debug.Log("Up/Down 2: " + Input.GetAxis("Joystick5 8th"));
            }
            if (Input.GetAxis("Joystick5 4th") != -1)//(default -1, range from -1 to 1)
            {
                //Debug.Log("Left Trigger 2: " + Input.GetAxis("Joystick5 4th"));
            }
            if (Input.GetAxis("Joystick5 5th") != -1)//(default -1, range from -1 to 1)
            {
                //Debug.Log("Right Trigger 2: " + Input.GetAxis("Joystick5 5th"));
            }
        }
    }

    void Contoller6KeyMapping()
    {
        if (Input.GetJoystickNames().Length < 6)
        {
            return;
        }
        if (Input.GetJoystickNames()[5].Contains("Xbox"))
        {
            if (Input.GetKeyDown(KeyCode.Joystick6Button0))
            {
                //Debug.Log("A/X");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button1))
            {
                //Debug.Log("B/O");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button2))
            {
                //Debug.Log("X/□");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button3))
            {
                //Debug.Log("Y/△");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button4))
            {
                player.Rush();
                //Debug.Log("Left Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button5))
            {
                player.UseWeapon();
                //Debug.Log("Right Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button6))
            {
                //Debug.Log("View");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button7))
            {
                GameManager.instance.PauseGame();
                //Debug.Log("Menu");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button8))
            {
                //Debug.Log("L");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button9))
            {
                //Debug.Log("R");
            }
            if (Input.GetAxis("Joystick6 X") != 0)
            {
                //Debug.Log("LeftStickHorizontal 2: " + Input.GetAxis("Joystick6 X"));
            }
            player.Move(Input.GetAxis("Joystick6 X"));
            if (Input.GetAxis("Joystick6 Y") != 0)
            {
                //Debug.Log("LeftStickVertical 2: " + Input.GetAxis("Joystick6 Y"));
            }
            if (Input.GetAxis("Joystick6 4th") != 0)
            {
                //Debug.Log("RightStickHorizontal 2: " + Input.GetAxis("Joystick6 4th"));
            }
            if (Input.GetAxis("Joystick6 5th") != 0)
            {
                //Debug.Log("RightStickVertical 2: " + Input.GetAxis("Joystick6 5th"));
            }
            player.LookAt(Input.GetAxis("Joystick6 5th"), Input.GetAxis("Joystick6 4th"));
            if (Input.GetAxis("Joystick6 6th") != 0)
            {
                //Debug.Log("Right/Left 2: " + Input.GetAxis("Joystick6 6th"));
            }
            if (Input.GetAxis("Joystick6 7th") != 0)
            {
                //Debug.Log("Up/Down 2: " + Input.GetAxis("Joystick6 7th"));
            }
            if (Input.GetAxis("Joystick6 9th") != 0)
            {
                //Debug.Log("Left Trigger 2: " + Input.GetAxis("Joystick6 9th"));
            }
            if (Input.GetAxis("Joystick6 10th") != 0)
            {
                //Debug.Log("Right Trigger 2: " + Input.GetAxis("Joystick6 10th"));
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Joystick6Button1))
            {
                //Debug.Log("A/X");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button2))
            {
                //Debug.Log("B/O");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button0))
            {
                //Debug.Log("X/□");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button3))
            {
                //Debug.Log("Y/△");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button4))
            {
                player.Rush();
                //Debug.Log("Left Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button5))
            {
                player.UseWeapon();
                //Debug.Log("Right Bumper");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button6))
            {
                //Debug.Log("Left Trigger");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button7))
            {
                //Debug.Log("Right Trigger");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button8))
            {
                //Debug.Log("View");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button9))
            {
                GameManager.instance.PauseGame();
                //Debug.Log("Menu");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button10))
            {
                //Debug.Log("L");
            }
            if (Input.GetKeyDown(KeyCode.Joystick6Button11))
            {
                //Debug.Log("R");
            }
            if (Input.GetAxis("Joystick6 X") != 0)
            {
                //Debug.Log("LeftStickHorizontal 2: " + Input.GetAxis("Joystick6 X"));
            }
            player.Move(Input.GetAxis("Joystick6 X"));
            if (Input.GetAxis("Joystick6 Y") != 0)
            {
                //Debug.Log("LeftStickVertical 2: " + Input.GetAxis("Joystick6 Y"));
            }
            if (Input.GetAxis("Joystick6 3rd") != 0)
            {
                //Debug.Log("RightStickHorizontal 2: " + Input.GetAxis("Joystick6 3rd"));
            }
            if (Input.GetAxis("Joystick6 6th") != 0)
            {
                //Debug.Log("RightStickVertical 2: " + Input.GetAxis("Joystick6 6th"));
            }
            player.LookAt(Input.GetAxis("Joystick6 6th"), Input.GetAxis("Joystick6 3rd"));
            if (Input.GetAxis("Joystick6 7th") != 0)
            {
                //Debug.Log("Right/Left 2: " + Input.GetAxis("Joystick6 7th"));
            }
            if (Input.GetAxis("Joystick6 8th") != 0)
            {
                //Debug.Log("Up/Down 2: " + Input.GetAxis("Joystick6 8th"));
            }
            if (Input.GetAxis("Joystick6 4th") != -1)//(default -1, range from -1 to 1)
            {
                //Debug.Log("Left Trigger 2: " + Input.GetAxis("Joystick6 4th"));
            }
            if (Input.GetAxis("Joystick6 5th") != -1)//(default -1, range from -1 to 1)
            {
                //Debug.Log("Right Trigger 2: " + Input.GetAxis("Joystick6 5th"));
            }
        }
    }
}
