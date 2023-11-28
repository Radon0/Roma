using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Click : MonoBehaviour
{

    private Rigidbody rb;
    public float Readytime;//�n�܂鎞��
    public Text ReadyText;//
    [SerializeField] Text EndText;//Ready���Ԃ��߂������̕���
    [SerializeField] GameObject Endcall;//Ready���Ԃ��߂������̃Q�[���I�u�W�F�N�g
    public bool Gmick = false;
    private GameObject targetObject;
    public Vector2 rotationSpeed = new Vector2(0.1f, 0.2f);
    public bool reverse;   
    private Vector2 lastMousePosition;
    private void Start()
    {
        targetObject = this.gameObject;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;//���W�b�g�{�f�B���̋@�\���I�t
      
    }
    //void OnCollisionEnter(Collision collision)//�n�ʂɐڐG�����Ƃ���]
    //{
    //    Debug.Log("��������");
        
    //}
    void Update()
    {
        if (Gmick == false)
        {
            if (Input.GetMouseButtonDown(1))
            {
                lastMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButton(1))
            {
                if (!reverse)
                {
                    var x = (Input.mousePosition.y - lastMousePosition.y);
                    var newAngle = Vector3.zero;
                    newAngle.x = x * rotationSpeed.x;
                    targetObject.transform.Rotate(newAngle);
                    lastMousePosition = Input.mousePosition;
                }
                else
                {
                    var x = (lastMousePosition.y - Input.mousePosition.y);                   
                    var newAngle = Vector3.zero;
                    newAngle.x = x * rotationSpeed.x;                 
                    targetObject.transform.Rotate(newAngle);
                    lastMousePosition = Input.mousePosition;
                }
            }
        }

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

    //�����ꂽ��
    private void OnMouseDown()
    {      
        if (Gmick == false)
        {
            rb.isKinematic = true;
        }
    }
    //�h���b�O���ꂽ��
    private void OnMouseDrag()
    {
        if (Gmick == false)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                transform.position = new Vector3(hit.point.x, -48, hit.point.z);              
            }
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
    //���͕����Ă��邯��Y�������킹��
    private void OnMouseUp()//�@��������
    {
        rb.isKinematic = false;
    }
}


