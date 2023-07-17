using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    [SerializeField] private GameObject _fishPrefab;
    [SerializeField] private Transform _rangeA;
    [SerializeField] private Transform _rangeB;
    [SerializeField] float _timer;
    [SerializeField] float _limit;

    void Start()
    {
        
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _limit )
        {
            float x = Random.Range(_rangeA.position.x, _rangeB.position.x);
            float y = Random.Range(_rangeA.position.y, _rangeB.position.y);
            float z = Random.Range(_rangeA.position.z, _rangeB.position.z);
            Instantiate(_fishPrefab, new Vector3(x, y, z), Quaternion.identity);
            _timer = 0;
        }
    }
}
