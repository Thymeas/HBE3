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
    //[SerializeField] private Button _keyboard;
    //private PlayerMovement _player1, _player2;
    private bool _hasSelecterKeyboard;
    private AudioSource _audio;
    public int player;

    private void Start()
    {
       DontDestroyOnLoad(this);
        _audio = FindObjectOfType<AudioSource>();
        //_player1 = FindObjectOfType<One>().GetComponent<PlayerMovement>();
        //_player2 = FindObjectOfType<Two>().GetComponent<PlayerMovement>();
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

    //    _keyboard.interactable = false;
    //}

    //public void Controller()
    //{
    //    if (player < 2)
    //        player += 1;
    //}
}
