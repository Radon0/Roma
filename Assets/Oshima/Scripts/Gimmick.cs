using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gimmick : MonoBehaviour
{
    [SerializeField] Slider iineSlider;
    //public GameObject gimmick;
    private Vector3 defaultPos;
    private Vector3 defaultLocate;
    public List<GameObject> myList = new List<GameObject>();//一応複数のギミックをやれるようにはしている        
    private int GimimckCount;

    private void Start()
    {
        defaultPos = new Vector3(3, 0, 0);//位置
        defaultLocate = new Vector3(0, 0, 0);//回転
    }
    public void ClickStartButton()
    {         //valueの値でcaseを変えている
        switch (iineSlider.value)
        {
            case 10:

                GimimckCount += 1;
                if (GimimckCount <= 3)//3回ギミック表示
                {
                    Instantiate(myList[0]);
                    myList[0].transform.position = defaultPos;

                }
                iineSlider.value = 0;
                break;

            case 20:
                GimimckCount += 1;
                if (GimimckCount <= 3)
                {
                    Instantiate(myList[1]);
                    myList[1].transform.position = defaultPos;
                }
                iineSlider.value = 0;
                break;

            case 30:
                GimimckCount += 1;
                if (GimimckCount <= 3)
                {
                    Instantiate(myList[2]);
                    myList[2].transform.position = defaultPos;
                }
                iineSlider.value = 0;
                break;
        }
    }
}
