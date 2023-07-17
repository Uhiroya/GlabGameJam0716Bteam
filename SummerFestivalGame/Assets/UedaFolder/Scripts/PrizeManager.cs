using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeManager : MonoBehaviour
{
    [SerializeField] int _prizeCost = 100;
    float _move;
    // Start is called before the first frame update
    void Start()
    {
         _move = GetComponentInParent<RailManager>().MoveSpeed;
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
        if(other.gameObject.tag == "RightWall" && _move > 0f)
        {
            this.gameObject.transform.position = new Vector3(-12f, transform.position.y, transform.position.z);
        }
        if (other.gameObject.tag == "LeftWall" && _move < 0f)
        {
            this.gameObject.transform.position = new Vector3(12f, transform.position.y, transform.position.z);
        }
    }
}
