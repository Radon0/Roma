using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gimmick : MonoBehaviour
{
    [SerializeField] Slider iineSlider;
    public bool click=false;// クリックした位置座標
    public Button button;
    public GameObject game;
    public bool Open=false;
    
    private void Start()
    {
        button = GetComponent<Button>();
    }
    
    public void ClickStartButton()
    {
        if (iineSlider.value == iineSlider.maxValue)
        {     
               button.interactable = false;
               click = true;
               Open = true;
            Invoke("DisableButton", 0.0001f);



            //if (!Open)
            //{
            //    Open = false; 
            //    // ボタンが押されたときにインスタンスを生成
            //   destroy= Instantiate(game, transform.position, Quaternion.identity);

            //}
            //else if(Open==true)
            //{
            //    Destroy(destroy);
            //}

        }

    }
    private void DisableButton()
    {
        // Set the interactable property to false after 3 seconds
        Open = false;
    }
}
