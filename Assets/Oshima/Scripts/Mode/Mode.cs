using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mode : MonoBehaviour
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
            SceneManager.LoadScene("Round1");

    }

    public void Onclick()
    {
        audioSource.Play();
        isAudioEnd = true;
    }

    //public void ClickStartButton()
    //{
    //    SceneManager.LoadScene("HP");//éüÇ…à⁄çsÇ∑ÇÈÉVÅ[Éì
    //}
}
