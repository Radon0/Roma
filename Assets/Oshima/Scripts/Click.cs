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
    Vector3 nowmouseposi;
    Vector3 diffposi;
    public GameObject targetObject;
    public Vector2 rotationSpeed = new Vector2(0.1f, 0.2f);
    public bool reverse;
    public bool Drag = false;

    private Camera mainCamera;
    private Vector2 lastMousePosition;
    private void Start()
    {
        //mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;//���W�b�g�{�f�B���̋@�\���I�t
        Endcall.SetActive(false);
    }
    void OnCollisionEnter(Collision collision)//�n�ʂɐڐG�����Ƃ���]
    {
        Debug.Log("��������");
        Drag = false;
    }
    void Update()
    {
        if (Gmick == false & Drag == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                if (!reverse)
                {
                    var x = (Input.mousePosition.y - lastMousePosition.y);
                    //var y = (lastMousePosition.x - Input.mousePosition.x);

                    var newAngle = Vector3.zero;
                    newAngle.x = x * rotationSpeed.x;
                    //newAngle.y = y * rotationSpeed.y;

                    targetObject.transform.Rotate(newAngle);
                    lastMousePosition = Input.mousePosition;
                }
                else
                {
                    var x = (lastMousePosition.y - Input.mousePosition.y);
                    //var y = (Input.mousePosition.x - lastMousePosition.x);

                    var newAngle = Vector3.zero;
                    newAngle.x = x * rotationSpeed.x;
                    //newAngle.y = y * rotationSpeed.y;

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
        Drag = false;
        if (Gmick == false)
        {

            rb.isKinematic = true;
        }
    }
    //�h���b�O���ꂽ��
    private void OnMouseDrag()
    {
        Drag = false;
        if (Gmick == false)
        {

            //Vector3 nowmouseposi;
            //Vector3 diffposi;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            transform.position = ray.GetPoint(80f);

            ////���݂̃}�E�X�̃��[���h���W���擾
            //nowmouseposi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //////��O�̃}�E�X���W�Ƃ̍������v�Z���ĕω��ʂ��擾
            //diffposi = nowmouseposi - _nowMousePosi;
            //////�J�n���̃I�u�W�F�N�g�̍��W�Ƀ}�E�X�̕ω��ʂ𑫂��ĐV�������W��ݒ�
            //GetComponent<Transform>().position += diffposi;
            //////���݂̃}�E�X�̃��[���h���W���X�V
            //_nowMousePosi = nowmouseposi;

        }
    }
    private void OnMouseEnter()//�@�����Ă�����
    {
        Drag = true;
        if (Gmick == false)
        {

            transform.localScale *= 1.5f;
        }
    }
    private void OnMouseExit()  //�@�o�Ă������Ƃ�
    {
        Drag = true;
        if (Gmick == false)
        {

            transform.localScale /= 1.5f;
        }
    }
    private void OnMouseUp()//�@��������
    {
        Drag = true;
        rb.isKinematic = false;
    }
    //private void OnMouseUpAsButton() //�@�I�u�W�F�N�g��ł͂Ȃ�����
    //{
    //}

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    // �����J�n�@�t���O�𗧂Ă�
    //    Gmick = false;
    //    // �}�E�X�̃��[���h���W��ۑ�
    //    _nowMousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    // �����I���@�t���O�𗎂Ƃ�
    //    Gmick =true;
    //    _nowMousePosi = Vector3.zero;
    //}

    //    Drag = true;
    //    if (Gmick == false & Drag == true)
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            lastMousePosition = Input.mousePosition;
    //        }
    //        else if (Input.GetMouseButton(0))
    //        {
    //            if (!reverse)
    //            {
    //                var x = (Input.mousePosition.y - lastMousePosition.y);
    //                //var y = (lastMousePosition.x - Input.mousePosition.x);

    //                var newAngle = Vector3.zero;
    //                newAngle.x = x * rotationSpeed.x;
    //                //newAngle.y = y * rotationSpeed.y;

    //                targetObject.transform.Rotate(newAngle);
    //                lastMousePosition = Input.mousePosition;
    //            }
    //            else
    //            {
    //                var x = (lastMousePosition.y - Input.mousePosition.y);
    //                //var y = (Input.mousePosition.x - lastMousePosition.x);

    //                var newAngle = Vector3.zero;
    //                newAngle.x = x * rotationSpeed.x;
    //                //newAngle.y = y * rotationSpeed.y;

    //                targetObject.transform.Rotate(newAngle);
    //                lastMousePosition = Input.mousePosition;
    //            }
    //        }
    //    }
    //}
}


