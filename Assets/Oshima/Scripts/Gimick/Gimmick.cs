using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gimmick : MonoBehaviour
{
    [SerializeField] Slider iineSlider;
    //public GameObject gimmick;
    private Vector3 defaultPos;
    public List<GameObject> myList = new List<GameObject>();//�ꉞ�����̃M�~�b�N������悤�ɂ͂��Ă���        
    private int GimimckCount;//�M�~�b�N�̕\����


    private void Start()
    {
        defaultPos = new Vector3(-21, -54, 0);//�ʒu
    }
    public void ClickStartButton()
    {           
        switch (iineSlider.value)
        {         
            case 10:
                GimimckCount += 1;
                if (GimimckCount <= 6)//6��M�~�b�N�\��
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
