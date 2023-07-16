using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoopController : MonoBehaviour
{
    //カーソル座標を取得するための変数
    Vector3 _screenPoint;
    //スコア用の変数
    int _score = 0;
    //スコア用のテキスト
    [SerializeField] Text _text;
    //金魚1のスコア
    [SerializeField] int _fish1Point;

    void Start()
    {
        
    }

    
    void Update()
    {
        this._screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
        transform.position = Camera.main.ScreenToWorldPoint(a);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("T");
        if(other.gameObject.tag == "Fish1")
        {
            Debug.Log("Fish1");
            _score += _fish1Point;
        }

        SetScore();
    }

    void SetScore()
    {
        _text.text = _score.ToString();
    }
}
