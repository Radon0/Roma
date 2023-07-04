using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click :MonoBehaviour
{
    private Rigidbody rb;
    public float Readytime;//�n�܂鎞��
    public Text ReadyText;//
    [SerializeField] Text EndText;//Ready���Ԃ��߂������̕���
    [SerializeField] GameObject Endcall;//Ready���Ԃ��߂������̃Q�[���I�u�W�F�N�g
    private bool Gmick=false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;//���W�b�g�{�f�B���̋@�\���I�t
        Endcall.SetActive(false);
    }
    void Update()
    {
        if (1 < Readytime)
        {
            Readytime -= Time.deltaTime;
            ReadyText.text = Readytime.ToString("0");//���s���邽�߂̋󔒂����Ȃ���
        }
        else if (Readytime <= 1f)
        {
            Gmick = true;
            Destroy(ReadyText);
            Endcall.SetActive(true);
            EndText.text = "�I��!!";
            Destroy(EndText, 2f);
        }
    }

    //�@�����ꂽ��
    private void OnMouseDown()
    {
        if (Gmick == false)
        {
            rb.isKinematic = true;
        }
    }
    //�@�h���b�O���ꂽ��
    private void OnMouseDrag()
    {
        if (Gmick == false)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            transform.position = ray.GetPoint(10f);
        }
    }
    private void OnMouseEnter()//�@�����Ă�����
    {
        if (Gmick == false)
        {
            transform.localScale *= 1.5f;
        }
    }
    private void OnMouseExit()  //�@�o�Ă������Ƃ�
    {
        if (Gmick == false)
        {
            transform.localScale /= 1.5f;
        }
    }
    //private void OnMouseOver()    //�@��ɂ��鎞
    //{
        
    //}
    private void OnMouseUp()//�@��������
    {
        rb.isKinematic = false;
    }   
    //  private void OnMouseUpAsButton() //�@�I�u�W�F�N�g��ł͂Ȃ�����
    //{
      //rb.isKinematic = false;
      //mat.color = Color.gray;
    //}
}


