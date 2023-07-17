using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] float _timer;
    [SerializeField] AudioClip _audioSource;
    [SerializeField] AudioClip _audioSource2;
    [SerializeField] AudioClip _audioSource3;
    [SerializeField] AudioClip _audioSource4;
    AudioSource _audio;
    bool _playSound3 = true;
    bool _playSound4 = true;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        _text.text = _timer.ToString("F2");

       if(_timer <= 30 && _playSound3)
        {
            _audio.clip = _audioSource3;
            _audio.Play();
            _playSound3 = false;
        }
       else if(_timer <= 0.5f && _playSound4)
        {
            _audio.clip = _audioSource4;
            _audio.Play();
            _playSound4 = false;
        }
       else if( _timer <= 0)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
