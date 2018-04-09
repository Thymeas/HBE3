using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputControls : MonoBehaviour
{
     public PlayerMovement[] _players;

    public bool[] playerPickedController;
    public bool[] playerPickedKeyboard;

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
        DontDestroyOnLoad(this);

        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "Level1")
            {
                _players = FindObjectsOfType<PlayerMovement>();
                SetControllerToPlayer();
            }
        };
    }

    public void SetControllerToPlayer()
    {
        if (playerPickedKeyboard[0])
        {
            _players[0]._horizontalAxis = _horizontalK;
            _players[0]._verticalAxis = _verticalK;
            _players[0]._breakButton = _breakK;
        }

        if (playerPickedKeyboard[1])
        {
            _players[1]._horizontalAxis = _horizontalK;
            _players[1]._verticalAxis = _verticalK;
            _players[1]._breakButton = _breakK;
        }

        if (playerPickedController[0])
        {
            _players[0]._horizontalAxis = _horizontalJ1;
            _players[0]._verticalAxis = _verticalJ1;
            _players[0]._breakButton = _breakJ1;
        }

        if (playerPickedController[1])
        {
            _players[0]._horizontalAxis = _horizontalJ2;
            _players[0]._verticalAxis = _verticalJ2;
            _players[0]._breakButton = _breakJ2;

            if(!playerPickedController[0])
            {
                _players[0]._horizontalAxis = _horizontalJ1;
                _players[0]._verticalAxis = _verticalJ1;
                _players[0]._breakButton = _breakJ1;
            }
        }
    }
}
