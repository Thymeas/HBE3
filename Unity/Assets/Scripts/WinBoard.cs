using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinBoard : MonoBehaviour
{  
    public static string _winner;
    private Text winText;

    void Start()
    {
        SceneManager.sceneLoaded += (scene, mode) =>
        {
                if (scene.name == "WinScreen")
                {
                    winText = FindObjectOfType<Text>();
                    winText.text = _winner + " has won ";
            }        
        };
    }

    void Update()
    {
        
    }
}
