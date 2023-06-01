using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    private Vector3 defaultPos;
    private Material mat;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;//���W�b�g�{�f�B���̋@�\���I�t
        defaultPos = transform.position;
        mat = GetComponent<MeshRenderer>().material;
    }
    //�@�����ꂽ��
    private void OnMouseDown()
    {
        mat.color = Color.red;
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
    private void OnMouseOver()    //�@��ɂ��鎞
    {
        Debug.Log("OnMouseOver");
    }    
    private void OnMouseUp()//�@��������
    {
        rb.isKinematic = false;//���W�b�g�{�f�B���I��
    }   
    private void OnMouseUpAsButton() //�@�I�u�W�F�N�g��Řb������
    {
        mat.color = Color.gray;
    }
}


