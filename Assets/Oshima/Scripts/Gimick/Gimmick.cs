using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gimmick : MonoBehaviour
{
    [SerializeField] Slider iineSlider;
    public bool click=false;// �N���b�N�����ʒu���W
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
            //if (!Open)
            //{
            //    Open = false; 
            //    // �{�^���������ꂽ�Ƃ��ɃC���X�^���X�𐶐�
            //   destroy= Instantiate(game, transform.position, Quaternion.identity);
               
            //}
            //else if(Open==true)
            //{
            //    Destroy(destroy);
            //}

        }       
    }
}
