using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab ;
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

    // Update is called once per frame
    void Update()
    {
        _shotTime += Time.deltaTime;

        
        //Debug.Log($"mousePsition:{mousePosition}");
        if (Input.GetKeyDown(KeyCode.Mouse0) && _shotTime > _shotInterval)
        {
            GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -_camera.transform.position.z);
            var targetVector = _camera.ScreenToWorldPoint(mousePosition) - transform.position;
            //Debug.Log($"_camera.ScreenToWorldPoint(mousePosition):{_camera.ScreenToWorldPoint(mousePosition)}");
            //Debug.Log($"targetVector:{targetVector}");
            bulletRb.AddForce(targetVector.normalized * _shotSpeed,ForceMode.Impulse);
            //éÀåÇÇ≥ÇÍÇƒÇ©ÇÁ3ïbå„Ç…èeíeÇÃÉIÉuÉWÉFÉNÉgÇîjâÛÇ∑ÇÈ.
            Destroy(bullet, 3.0f);
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
