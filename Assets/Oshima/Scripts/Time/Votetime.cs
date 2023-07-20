using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Votetime : MonoBehaviour
{
    public float time = 3.0f;
    public Text timerText;
    void Update()
    {
        if (0 < time)
        {
            time -= Time.deltaTime;
            timerText.text = time.ToString("00");
        }
        else if (time < 0)
        {
            SceneManager.LoadScene("Spectator");

        }
    }
}

