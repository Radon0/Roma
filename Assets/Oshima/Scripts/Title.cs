using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void ClickStartButton()
    {
        SceneManager.LoadScene("HP");//次に移行するシーン
    }
}
