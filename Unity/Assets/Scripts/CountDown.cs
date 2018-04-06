using UnityEngine;

public class CountDown : MonoBehaviour {

    public float countdown = 4.0f;
    private float _time = 0;        
    private bool called = false; 

    void Update()
    {
        if (!called)
        {
            _time += Time.deltaTime;
            if (_time >= countdown)
            {
                called = true;
                StartRace();
            }
        }
    }

    void StartRace()
    {
        UIManager._canCount = true;
    }
}
