using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Cysharp.Threading.Tasks;
public class GunManager : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab ;
    [SerializeField] Slider _chargeSlider;
    [SerializeField] Camera _camera ;
    [SerializeField] float _shotSpeed;
    [SerializeField] int MaxMagazine = 5;
    [SerializeField] int _reloadCost = 500;
    
    int _shotCount = 0;
    float _shotInterval = 0.5f;
    float _shotTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float value = 10000;
    async UniTask<float> ChargeShot() 
    {
        int count = 1;
        float result = 0f;
        while (true)
        {
            result = Mathf.Pow(count , 1.8f);
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                break;
            }
            if (result > value)
            {
                result = 0f;
                count = 1;
            }
            await UniTask.DelayFrame(1);
            count++;
            _chargeSlider.value = result / value;
            Debug.Log($"result{result}");
        }
        return result / value;
    }
    // Update is called once per frame
    async void Update()
    {
        _shotTime += Time.deltaTime;

        
        //Debug.Log($"mousePsition:{mousePosition}");
        if (Input.GetKeyDown(KeyCode.Mouse0) && _shotTime > _shotInterval)
        {
            var result = await ChargeShot();
            Debug.Log($"result{result}");
            GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -_camera.transform.position.z);
            var targetVector = _camera.ScreenToWorldPoint(mousePosition) - transform.position;
            //Debug.Log($"_camera.ScreenToWorldPoint(mousePosition):{_camera.ScreenToWorldPoint(mousePosition)}");
            //Debug.Log($"targetVector:{targetVector}");
            bulletRb.AddForce(targetVector.normalized * _shotSpeed * result,ForceMode.Impulse);

            Destroy(bullet, 1.5f);
            _shotTime = 0f;
            _shotCount++;
            if (_shotCount % MaxMagazine == 0)
            {
                SaveManager.Money -= _reloadCost;
                Debug.Log($"nowMoney{SaveManager.Money}");
            }
            
        }

    }
}
