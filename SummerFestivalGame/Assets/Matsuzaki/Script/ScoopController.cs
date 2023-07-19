using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoopController : MonoBehaviour
{
    //カーソル座標を取得するための変数
    Vector3 _screenPoint;
    //スコア用の変数
    public static int _score = 0;
    //スコア用のテキスト
    [SerializeField] Text _text;
    //金魚1のスコア
    [SerializeField] int _fish1Point = 100;
    [SerializeField] int _fish2Point = 300;
    [SerializeField] int _fish3Point = 1000;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioSource _audioSource2;

    private bool _isFish1 = false;
    private bool _isFish2 = false;
    private bool _isFish3 = false;
    private FishController _fishController = default;


    void Start()
    {
        _score = 0;
    }

    
    void Update()
    {
        this._screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 a = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
        transform.position = Camera.main.ScreenToWorldPoint(a);

        if (Input.GetMouseButtonDown(0) && _isFish1)
        {
            GameObject.Find("net").GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.75f);
            _audioSource.Play();
            _score += _fish1Point;
            _fishController.FishDestroy();
            SetScore();
            _isFish1 = false;
        }
        else if (Input.GetMouseButtonDown(0) && _isFish2)
        {
            GameObject.Find("net").GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.75f);
            _audioSource.Play();
            _score += _fish2Point;
            _fishController.FishDestroy();
            SetScore();
            _isFish2 = false;
        }
        else if (Input.GetMouseButtonDown(0) && _isFish3)
        {
            GameObject.Find("net").GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.75f);
            _audioSource.Play();
            _score += _fish3Point;
            _fishController.FishDestroy();
            SetScore();
            _isFish3 = false;
        }
        else if(Input.GetMouseButtonDown(0))
        {
            _audioSource2.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fish1")
        {
            _audioSource2.Play();
            GameObject.Find("net").GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
            _isFish1 = true;
            _fishController = other.gameObject.GetComponent<FishController>();
        }
        else if(other.gameObject.tag == "Fish2")
        {
            _audioSource2.Play();
            GameObject.Find("net").GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
            _isFish2 = true;
            _fishController = other.gameObject.GetComponent<FishController>();
        }
        else if(other.gameObject.tag == "Fish3")
        {
            _audioSource2.Play();
            GameObject.Find("net").GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
            _isFish3 = true;
            _fishController = other.gameObject.GetComponent<FishController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fish1")
        {
            GameObject.Find("net").GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.75f);
            _isFish1 = false;
        }
        else if(other.gameObject.tag == "Fish2")
        {
            GameObject.Find("net").GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.75f);
            _isFish2 = false;
        }
        else if(other.gameObject.tag == "Fish3")
        {
            GameObject.Find("net").GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.75f);
            _isFish3 = false;
        }
    }

    void SetScore()
    {
        _text.text = _score.ToString();
    }
}
