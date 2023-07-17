using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FishController : MonoBehaviour
{
    [SerializeField] private float _timer;
    void Start()
    {
        
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if ( _timer >= 7.5)
        {
            Destroy(gameObject);
        }
    }

    public void FishDestroy()
    {
        Destroy(gameObject);
    }
}
