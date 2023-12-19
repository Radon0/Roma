using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isAudioEnd;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!audioSource.isPlaying && isAudioEnd)
            SceneManager.LoadScene("Mode");

    }

    public void Onclick()
    {
        audioSource.Play();
        isAudioEnd = true;
    }
}
