using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMenu : MonoBehaviour
{
    public string[] _horizontalAxis, _verticalAxis, _jumpButton, _breakButton;
    private float[] _inputHorizontal, _inputVertical;
    [SerializeField] private GameObject[] screens;

    public void PlayMenu()
    {
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(false);
        }
        screens[2].SetActive(true);
    }

    public void OptionsMenu()
    {
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(false);
        }
        screens[3].SetActive(true);
    }

    public void HowToMenu()
    {
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(false);
        }
        screens[1].SetActive(true);
    }

    public void P1IsUsingController()
    {

    }

    public void P1IsUsingKeyboard()
    {
        
    }


    public void P2IsUsingController()
    {

    }

    public void P2IsUsingKeyboard()
    {

    }

    public void BackButton()
    {
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(false);
        }
        screens[0].SetActive(true);
    }

    public void MuteMusic()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
