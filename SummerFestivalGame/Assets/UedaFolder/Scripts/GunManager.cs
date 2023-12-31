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
    [SerializeField] int MaxChargeFrame = 5;
    [SerializeField] float _shotSpeed;
    [SerializeField] int MaxMagazine = 5;
    [SerializeField] int _reloadCost = 500;
    
    int _shotCount = 0;
    float _shotInterval = 0.5f;
    float _shotTime = 0f;
    AudioSource _audioSource ;
    AudioClip _audioClip ;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    float MaxChargeTime = 10f;
    async UniTask<float> ChargeShot() 
    {
        float count = Time.deltaTime + 1f;
        float result = 0f;
        while (!Input.GetKeyUp(KeyCode.Mouse0))
        {
            result = Mathf.Pow(count,4f) ;        
            if (result > MaxChargeTime )
            {
                bool flag = await MaxChargeShot();
                if (!flag)
                {
                    result = 0f;
                    count = 1;
                }
                else
                {
                    result = MaxChargeTime;
                    break;
                }
            }
            await UniTask.DelayFrame(1);
            count += Time.deltaTime;
            _chargeSlider.value = result / MaxChargeTime;
            //Debug.Log($"result{result}");
        }
        return result / MaxChargeTime;
    }


        
    async UniTask<bool> MaxChargeShot()
    {
        int Frame = 0;
        bool result = false;
        while (Frame < MaxChargeFrame)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                result = true;
                break;
            }
            await UniTask.DelayFrame(1);
            Frame += 1;
        }
        return result;
    }
    // Update is called once per frame
    async void Update()
    {
        _shotTime += Time.deltaTime;

        
        //Debug.Log($"mousePsition:{mousePosition}");
        if (Input.GetKeyDown(KeyCode.Mouse0) && _shotTime > _shotInterval)
        {
            var result = await ChargeShot();
            _audioSource.PlayOneShot(_audioSource.clip);
            result = Mathf.Clamp(result, 0.3f, 1f);
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
