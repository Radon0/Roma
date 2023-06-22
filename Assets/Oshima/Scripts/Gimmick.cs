using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gimmick : MonoBehaviour
{
    [SerializeField] Slider iineSlider;
    public GameObject gimmick;
    //private Vector3 defaultPos;
    //private Vector3 defaultLocate;
    public List<GameObject> myList = new List<GameObject>();//一応複数のギミックをやれるようにはしている        
    private int GimimckCount;

    private void Start()
    {
        //gimmick.transform.localPosition = new Vector3(0, 0, 0);
        //gimmick.transform.position = new Vector3(0, 0, 0);
        //defaultPos = gimmick.transform.position;
        //defaultLocate = gimmick.transform.localPosition;
    }
    public void ClickStartButton()
    {         //valueの値でcaseを変えている
        switch (iineSlider.value)
        {
            case 10:
                GimimckCount += 1;
                //gimmick.transform.localPosition = defaultLocate;
                //gimmick.transform.position = defaultPos;
                if (GimimckCount <= 3)
                {
                    //Instantiate(gimmick);
                    //gimmick.SetActive(true);
                    Instantiate(myList[0]);
                }
                iineSlider.value = 0;
                break;
            case 20:

                GimimckCount += 1;
                //gimmick.transform.localPosition = defaultLocate;
                //gimmick.transform.position = defaultPos;
                if (GimimckCount <= 3)
                {
                    //Instantiate(gimmick);
                    //gimmick.SetActive(true);
                    Instantiate(myList[1]);
                }
                iineSlider.value = 0;
                break;
            case 30:

                GimimckCount += 1;
                //gimmick.transform.localPosition = defaultLocate;
                //gimmick.transform.position = defaultPos;
                if (GimimckCount <= 3)
                {
                    //Instantiate(gimmick);
                    //gimmick.SetActive(true);
                    Instantiate(myList[2]);
                }
                iineSlider.value = 0;
                break;
        }
    }
}
