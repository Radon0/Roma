using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gimmick : MonoBehaviour
{
    [SerializeField] Slider iineSlider;
    Button Gimmickbutton;
    //public GameObject gimmick;
    public List<GameObject> myList= new List<GameObject>();//�ꉞ�����̃M�~�b�N������悤�ɂ͂��Ă���        
    public void ClickStartButton()
    {   
        if (iineSlider.value==30)//�X���C�_�[��value��30�̎��ɃM�~�b�N�\��
        {
            myList[0].SetActive(true);
            //gameObject.SetActive(true);
        }
    }


}
