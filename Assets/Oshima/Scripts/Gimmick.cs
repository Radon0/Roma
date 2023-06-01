using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gimmick : MonoBehaviour
{
    [SerializeField] Slider iineSlider;
    Button Gimmickbutton;
    //public GameObject gimmick;
    public List<GameObject> myList= new List<GameObject>();//一応複数のギミックをやれるようにはしている        
    public void ClickStartButton()
    {   
        if (iineSlider.value==30)//スライダーのvalueが30の時にギミック表示
        {
            myList[0].SetActive(true);
            //gameObject.SetActive(true);
        }
    }


}
