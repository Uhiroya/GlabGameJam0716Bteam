using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    
    [SerializeField]
    Text timeText;

   public  string sceneName;

    


    public int countdownMinutes = 3;
    private float countdownSeconds;  
    

    // Start is called before the first frame update
    void Start()
    {
               countdownSeconds = countdownMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss");

        if (countdownSeconds <= 0)
        {
            Invoke("ChangeScene", 1);
        }
            
        ExpressMoney();
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
