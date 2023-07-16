using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeManager : MonoBehaviour
{
    [SerializeField] int _prizeCost = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Finish")
        {
            SaveManager.Money += _prizeCost;
            Debug.Log($"nowMoney{SaveManager.Money}");
            Destroy(this.gameObject);
        }
    }
}
