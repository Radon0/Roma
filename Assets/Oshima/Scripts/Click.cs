using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    //private Material mat;
   // public BoxCollider Box;
    private Rigidbody rb;
    private bool Gimick=false;
    private void Start()
    {
       // Box = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;//���W�b�g�{�f�B���̋@�\���I�t       
    }
   
    
    //�@�����ꂽ��
    private void OnMouseDown()
    {
        if (Gimick == false)
        {
            rb.isKinematic = true;
        }
    }
    //�@�h���b�O���ꂽ��
    private void OnMouseDrag()
    {
        if (Gimick == false)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            transform.position = ray.GetPoint(10f);
        }
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
        Gimick = true;
        // Box.enabled = false;
        rb.isKinematic = false;//���W�b�g�{�f�B���I��
    }   
    //  private void OnMouseUpAsButton() //�@�I�u�W�F�N�g��ł͂Ȃ�����
    //{
      //rb.isKinematic = false;
      //mat.color = Color.gray;
    //}
}


