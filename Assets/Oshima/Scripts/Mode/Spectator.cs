using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spectator : MonoBehaviour
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
            SceneManager.LoadScene("Vote");

    }

    public void Onclick()
    {
        audioSource.Play();
        isAudioEnd = true;
    }
    //public void ClickStartButton()
    //{
    //    SceneManager.LoadScene("Vote");//éüÇ…à⁄çsÇ∑ÇÈÉVÅ[Éì
    //}
}
