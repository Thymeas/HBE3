using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputMenu : MonoBehaviour
{
    public string[] _horizontalAxis, _verticalAxis, _jumpButton, _breakButton;
    private float[] _inputHorizontal, _inputVertical;
    [SerializeField] private GameObject[] screens;
    private InputControls _controls;

    [NonSerialized] public Button _keyboard;

    //private PlayerMovement _player1, _player2;
    private bool _hasSelecterKeyboard;

    private AudioSource _audio;
    public int player;
    private bool canLoadLevel = true;

    public enum controls
    {
        KEYBOARD,
        CONTROLLER
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
        _audio = FindObjectOfType<AudioSource>();
        _controls = FindObjectOfType<InputControls>();
        //_player1 = FindObjectOfType<One>().GetComponent<PlayerMovement>();
        //_player2 = FindObjectOfType<Two>().GetComponent<PlayerMovement>();
    }

    //void Update()
    //{
    //    if (player >= 2 && canLoadLevel)
    //    {
    //        DoneButton();
    //        canLoadLevel = false;
    //    }
    //}

    public void DoneButton()
    {
      LoadLevel();
    }

    public void PlayMenu()
    {
        LoadLevel();
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
        _audio.mute = !_audio.mute;
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    public static void LoadWinScreen()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    //public void Keyboard()
    //{
    //    if (player < 2)
    //        player += 1;

    //    PlayerControllerCheck(controls.KEYBOARD, player);
    //    if(_keyboard!= null)
    //    _keyboard.interactable = false;
    //}

    //public void Controller()
    //{
    //    if (player < 2)
    //        player += 1;

    //    PlayerControllerCheck(controls.CONTROLLER, player);
    //}

    //private void PlayerControllerCheck(controls controller, int player)
    //{
    //    switch (player)
    //    {
    //        case 0:
    //            break;
    //        case 1:
    //            if (controller == controls.KEYBOARD)
    //                _controls.SetKeyboardToPlayer(player);
    //                break;
    //        case 2:
    //            if (controller == controls.KEYBOARD)
    //                _controls.SetControllerToPlayer(player);
    //            break;
    //    }
    //}
}
