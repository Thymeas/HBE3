using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputControls : MonoBehaviour
{
     public PlayerMovement[] _players;
    private InputMenu _menu;
    [NonSerialized] public static int _player;

    [NonSerialized] public string _horizontalJ1 = "L_XAxis_1";
    [NonSerialized] public string _horizontalJ2 = "L_XAxis_2";
    [NonSerialized] public string _horizontalK = "Horizontal";

    [NonSerialized] public string _verticalJ1 = "L_YAxis_1";
    [NonSerialized] public string _verticalJ2 = "L_YAxis_2";
    [NonSerialized] public string _verticalK = "Vertical";

    [NonSerialized] public string _breakJ1 = "B_1";
    [NonSerialized] public string _breakJ2 = "B_2";
    [NonSerialized] public string _breakK = "Button_B";

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        _players = FindObjectsOfType<PlayerMovement>();
        _menu = FindObjectOfType<InputMenu>();
        //_players = _players.Reverse().ToArray();
    }

    public void SetKeyboardToPlayer(int player)
    {
        _players[player]._horizontalAxis = _horizontalK;
        _players[player]._verticalAxis = _verticalK;
        _players[player]._breakButton = _breakK;
    }

    public void SetControllerToPlayer(int player)
    {
        switch (player)
        {
            case 0:
                break;
            case 1:
                _players[player]._horizontalAxis = _horizontalJ1;
                _players[player]._verticalAxis = _verticalJ1;
                _players[player]._breakButton = _breakJ1;
                break;
            case 2:
                if (!_menu._keyboard.IsActive())
                {
                    _players[player]._horizontalAxis = _horizontalJ1;
                    _players[player]._verticalAxis = _verticalJ1;
                    _players[player]._breakButton = _breakJ1;
                }
                _players[player]._horizontalAxis = _horizontalJ2;
                _players[player]._verticalAxis = _verticalJ2;
                _players[player]._breakButton = _breakJ2;
                break;
        }
    }
}
