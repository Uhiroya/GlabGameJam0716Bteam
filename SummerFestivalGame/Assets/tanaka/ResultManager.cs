using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    Text GunResult;
    [SerializeField]
    Text FishResult;
    [SerializeField]
    Text SumResult;

    // Start is called before the first frame update
    void Start()
    {
        GunResult.text = $"{SaveManager.ShootResult}‰~";
        FishResult.text =$"{ScoopController._score}‰~";
        //SumResult.text = "" + UIManager.scoreText + "‰~";
        SumResult.text = $"{SaveManager.ShootResult + ScoopController._score}‰~";

        Invoke("ChangeScene", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
