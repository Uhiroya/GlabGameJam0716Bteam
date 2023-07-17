using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllor : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip[] _audioClips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Snack")
        {
            _audioSource.PlayOneShot(_audioClips[0]);
        }
        if (collision.gameObject.tag == "Robot")
        {
            _audioSource.PlayOneShot(_audioClips[1]);
        }
        if (collision.gameObject.tag == "Game")
        {
            _audioSource.PlayOneShot(_audioClips[2]);
        }
        if (collision.gameObject.tag == "RubberDuck")
        {
            _audioSource.PlayOneShot(_audioClips[3]);
        }
        Destroy(this.gameObject,0.1f);
    }
}
