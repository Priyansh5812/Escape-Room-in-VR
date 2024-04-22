using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BallView : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource _src;
    public AudioClip _impactClip;
    void Start()
    {
        _src = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            _src.PlayOneShot(_impactClip);   
        }
    }
}
