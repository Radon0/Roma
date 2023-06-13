using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gimmick : MonoBehaviour
{
    [SerializeField] Slider iineSlider;   
    public GameObject gimmick;
    private Vector3 defaultPos;
    private Vector3 defaultLocate;
    //public List<GameObject> myList= new List<GameObject>();//�ꉞ�����̃M�~�b�N������悤�ɂ͂��Ă���        
    private void Start()
    {
        gimmick.transform.localPosition = new Vector3(0, 0, 0);
        gimmick.transform.position = new Vector3(0, 0, 0);   
        defaultPos =gimmick.transform.position;
        defaultLocate = gimmick.transform.localPosition;
      
    }
    public void ClickStartButton()
    {   
        if (iineSlider.value==10)//�X���C�_�[��value��10�̎��ɃM�~�b�N�\��
        {
            gimmick.transform.localPosition = defaultLocate;
            gimmick.transform.position = defaultPos;
            //myList[0].SetActive(true);
            Instantiate(gimmick);
            gimmick.SetActive(true);         
            iineSlider.value = 0;           
           
        }
    }


}
