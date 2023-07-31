using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vote : MonoBehaviour
{
    public GameObject Player;
    public GameObject Yes_NO;
    // Start is called before the first frame update
    public void ClickStartButton()
    {
        Player.SetActive(false);
        Yes_NO.SetActive(true);
        
    }
}
