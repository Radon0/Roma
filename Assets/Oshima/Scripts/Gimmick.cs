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
    public List<GameObject> myList = new List<GameObject>();//�ꉞ�����̃M�~�b�N������悤�ɂ͂��Ă���        
    private int GimimckCount;

    private void Start()
    {
        defaultPos = new Vector3(3, 0, 0);//�ʒu
        defaultLocate = new Vector3(0, 0, 0);//��]
    }
    public void ClickStartButton()
    {         //value�̒l��case��ς��Ă���
        switch (iineSlider.value)
        {
            case 10:

                GimimckCount += 1;
                if (GimimckCount <= 3)//3��M�~�b�N�\��
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
