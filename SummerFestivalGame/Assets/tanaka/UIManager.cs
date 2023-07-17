using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;
using Cysharp.Threading.Tasks;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text timeText;
    [SerializeField]
    AudioSource _audioSource;
    [SerializeField]
    AudioClip _audioClip;
    public  string sceneName ; 
    public int countdownMinutes = 3;
    private float countdownSeconds;
    private bool _fastBGMflag = true;

    // Start is called before the first frame update
    void Start()
    {
        _fastBGMflag = true;
        countdownSeconds = countdownMinutes * 60;
    }

    // Update is called once per frame
    async void Update()
    {
        countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss");
        if(countdownSeconds < 32 && _fastBGMflag)
        {
            ChangeBGM();
            _fastBGMflag = false;
            //print("�Ă΂ꂽ");
        }
        if (countdownSeconds <= 0)
        {
            SaveManager.ShootResult = SaveManager.Money;
            Invoke("ChangeScene", 1);
        }
            
        ExpressMoney();
    }
    async void ChangeBGM()
    {
        await _audioSource.DOFade(0, 1f).AsyncWaitForCompletion(); 
        _audioSource.Stop();
        await UniTask.Delay(500);
        _audioSource.volume = 1f;
        _audioSource.PlayOneShot(_audioClip);
    }
    public void ExpressMoney()
    {
       // score += point;
        scoreText.text = "" + SaveManager.Money;
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
