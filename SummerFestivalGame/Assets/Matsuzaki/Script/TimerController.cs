using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] float _timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        _text.text = _timer.ToString("F2");

        if(_timer >= 0)
        {
            //ƒV[ƒ“‚ÌØ‚è‘Ö‚¦
        }
    }
}
