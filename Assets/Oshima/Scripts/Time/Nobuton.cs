using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nobuton : MonoBehaviour
{
    public List<Button> Vote;
    public GameObject NoButtom;
    public void ClickStartButton()
    {
        NoButtom.SetActive(false);
        Vote[0].interactable=true;
        Vote[1].interactable = true;
    }
}
