using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    //private Material mat;
   // public BoxCollider Box;
    private Rigidbody rb;
    //public float Readytime;//�n�܂鎞��
    //public Text ReadyText;//
    //[SerializeField] Text EndText;//Ready���Ԃ��߂������̕���
    //[SerializeField] GameObject Endcall;//Ready���Ԃ��߂������̃Q�[���I�u�W�F�N�g
    private void Start()
    {
       // Box = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;//���W�b�g�{�f�B���̋@�\���I�t
        //Endcall.SetActive(false);
        //ReadyText = GetComponent<Text>();
    }
    //void Update()
    //{
    //    if (1 < Readytime)
    //    {
    //        Readytime -= Time.deltaTime;
    //        ReadyText.text = Readytime.ToString("0");//���s���邽�߂̋󔒂����Ȃ���
    //    }
    //    else if (Readytime <= 1f)
    //    {
    //        Destroy(ReadyText);
    //        Endcall.SetActive(true);
    //        EndText.text = "�I��!!";
    //        Destroy(EndText, 2f);

    //    }
    //}

    //�@�����ꂽ��
    private void OnMouseDown()
    {
        rb.isKinematic = true;
    }
    //�@�h���b�O���ꂽ��
    private void OnMouseDrag()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.position = ray.GetPoint(10f);
    }
    private void OnMouseEnter()//�@�����Ă�����
    {
        transform.localScale *= 1.5f;
    }
    private void OnMouseExit()  //�@�o�Ă������Ƃ�
    {
        transform.localScale /= 1.5f;
    }
    //private void OnMouseOver()    //�@��ɂ��鎞
    //{
        
    //}
    private void OnMouseUp()//�@��������
    {
       // Box.enabled = false;
        rb.isKinematic = false;//���W�b�g�{�f�B���I��
    }   
    //  private void OnMouseUpAsButton() //�@�I�u�W�F�N�g��ł͂Ȃ�����
    //{
      //rb.isKinematic = false;
      //mat.color = Color.gray;
    //}
}


