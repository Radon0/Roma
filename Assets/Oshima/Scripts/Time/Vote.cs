using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Vote : MonoBehaviour
{
    public List<Button> Player;
    public GameObject aPlayer;
    public GameObject Yes_NO;
    //public List<Vote> vote;
    void Start()
    {

      }
    // Start is called before the first frame update
    public void ClickStartButton()
    {
        Player[0].interactable=false;
        Player[1].interactable = false;
        //aPlayer.SetActive(false);
        Yes_NO.SetActive(true);
        
    }
}