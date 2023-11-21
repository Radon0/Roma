using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Click : MonoBehaviour
{

    private Rigidbody rb;
    public float Readytime;//始まる時間
    public Text ReadyText;//
    [SerializeField] Text EndText;//Ready時間が過ぎた時の文字
    [SerializeField] GameObject Endcall;//Ready時間が過ぎた時のゲームオブジェクト
    public bool Gmick = false;
    public GameObject targetObject;
    public Vector2 rotationSpeed = new Vector2(0.1f, 0.2f);
    public bool reverse;
    public bool Drag = false;
    private Vector3 _nowMousePosi; // 現在のマウスのワールド座標
    private Vector2 lastMousePosition;
    private void Start()
    {
        //mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;//リジットボディをの機能をオフ
        Endcall.SetActive(false);
    }
    void OnCollisionEnter(Collision collision)//地面に接触したとき回転
    {
        Debug.Log("当たった");
        Drag = false;
    }
    void Update()
    {
        if (Gmick == false & Drag == true)
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
            ReadyText.text = Readytime.ToString("0");//改行するための空白けさないで
        }
        else if (Readytime <= 1f)
        {
            Gmick = true;
            Destroy(ReadyText);
            Endcall.SetActive(true);
            EndText.text = "終了!!";
            Destroy(EndText, 2f);
        }
    }

    //押された時
    private void OnMouseDown()
    {
        Drag = false;
        if (Gmick == false)
        {

            rb.isKinematic = true;
        }
    }
    //ドラッグされた時
    private void OnMouseDrag()
    {
        Drag = false;
        if (Gmick == false)
        {
            Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objPos.z);
            transform.position = Camera.main.ScreenToWorldPoint(mousePos);


        }
    }
    private void OnMouseEnter()//　入ってきた時
    {
        Drag = true;
        if (Gmick == false)
        {

            transform.localScale *= 1.5f;
        }
    }
    private void OnMouseExit()  //　出ていったとき
    {
        Drag = true;
        if (Gmick == false)
        {

            transform.localScale /= 1.5f;
        }
    }
    private void OnMouseUp()//　離した時
    {
        Drag = true;
        rb.isKinematic = false;
    }
}


