using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeSE : MonoBehaviour
{
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audio.Play();
        }
    }
}
