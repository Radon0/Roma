using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YesButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void ClickStartButton()
    {
        SceneManager.LoadScene("Spectator");
    }
}
