using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nobuton : MonoBehaviour
{
    public GameObject Vote;
    public GameObject NoButtom;
    public void ClickStartButton()
    {
        NoButtom.SetActive(false);
        Vote.SetActive(true);   
    }
}
