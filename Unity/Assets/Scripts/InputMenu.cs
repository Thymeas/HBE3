using UnityEngine;
using UnityEngine.SceneManagement;

public class InputMenu : MonoBehaviour
{
    public string[] _horizontalAxis, _verticalAxis, _jumpButton, _breakButton;
    private float[] _inputHorizontal, _inputVertical;
    [SerializeField] private GameObject[] screens;
    [SerializeField] private GameObject[] _controlButtons;
    private InputControls _controls;

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
    }

    void Update()
    {
        if (player >= 2 && canLoadLevel)
        {
            DoneButton();
            canLoadLevel = false;
        }  
    }

    public void DoneButton()
    {
      LoadLevel();
    }

    public void PlayMenu()
    {
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(false);
        }
        screens[2].SetActive(true);

        for (int i = 0; i < _controlButtons.Length; i++)
        {
            _controlButtons[i].SetActive(false);
        }
        _controlButtons[0].SetActive(true);
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

    public void Keyboardp1()
    {
        _controls.playerPickedKeyboard[player] = true;
        player += 1;

        nextPlayer();
    }

    public void Keyboardp2()
    {
        if(!_controls.playerPickedKeyboard[0])
        _controls.playerPickedKeyboard[player] = true;         

        player += 1;
    }

    public void ControllerP1()
    {
        _controls.playerPickedController[player] = true;
        player += 1;
        nextPlayer();
    }

    public void ControllerP2()
    {
        _controls.playerPickedController[player] = true;
        player += 1;
    }

    public void nextPlayer()
    {
        if (player == 1)
        {
            for (int i = 0; i < _controlButtons.Length; i++)
            {
                _controlButtons[i].SetActive(false);
            }
            _controlButtons[1].SetActive(true);
        }
    }
}
