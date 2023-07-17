using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAudioControllor : MonoBehaviour
{
    AudioSource _audioSource;
    [SerializeField]AudioClip[] _audioClipList;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Bullet")
        {
            foreach(AudioClip clip in _audioClipList)
            {
                _audioSource.PlayOneShot(clip);
            }
        }
    }
}
