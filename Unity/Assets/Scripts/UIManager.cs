using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text[] _timeText, _lapsText;
    [SerializeField] private float _time;
    [SerializeField] private float _countDown;
    [SerializeField] private PlayerMovement[] _players;
    [SerializeField] private AudioClip _countdownClip;
    public static bool _canCount;

    void Start()
    {
        _countDown = _countdownClip.length;
        _time = 0;
    }

    void Update()
    {
        _countDown -= 0.025f;
        if (_countDown <= 0)
            _canCount = true;

        if (_canCount)
            _time = Time.time;

        UpdateUI();
    }

    private void UpdateUI()
    {
        _timeText[0].text = "Time:" + "\n" + _time.ToString("F");
        _lapsText[0].text = "Lap:" + "\n" + _players[0]._lap + " / 3";

        _timeText[1].text = "Time:" + "\n" + _time.ToString("F");
        _lapsText[1].text = "Lap:" + "\n" + _players[1]._lap + " / 3";
    }
}
