using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    public static int Xbox360_Controller;
    public static int PS4_Controller;

    void Update()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            //print(names[x].Length);

            if (names[x].Length == 33)
            {
                Xbox360_Controller = 1;
            }
            if (names[x].Length == 44)
            {
                Xbox360_Controller = 2;
            }
        }


        switch (Xbox360_Controller)
        {
            case 1:
                
                break;
            case 2:
                
                break;
            default:
                // print(" IK HEB GEEN CONTROLLER MAAR WEL AIDS :D");
                break;
        }
    }
}