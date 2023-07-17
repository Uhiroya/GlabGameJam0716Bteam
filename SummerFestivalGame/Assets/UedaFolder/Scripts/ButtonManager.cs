using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Cysharp.Threading.Tasks;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] string _targetScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void OnDrop()
    {
        await UniTask.Delay(1000);
        SceneManager.LoadScene( _targetScene );
    }
}
