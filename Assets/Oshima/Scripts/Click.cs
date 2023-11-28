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
    private GameObject targetObject;
    public Vector2 rotationSpeed = new Vector2(0.1f, 0.2f);
    public bool reverse;   
    private Vector2 lastMousePosition;
    private void Start()
    {
        targetObject = this.gameObject;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;//リジットボディをの機能をオフ
      
    }
    //void OnCollisionEnter(Collision collision)//地面に接触したとき回転
    //{
    //    Debug.Log("当たった");
        
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
        if (Gmick == false)
        {
            rb.isKinematic = true;
        }
    }
    //ドラッグされた時
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
    private void OnMouseEnter()//　入ってきた時
    {
        if (Gmick == false)
        {
            transform.localScale *= 1.5f;
        }
    }
    private void OnMouseExit()  //　出ていったとき
    {
        if (Gmick == false)
        {
            transform.localScale /= 1.5f;
        }
    }
    //今は浮いているけどY軸を合わせる
    private void OnMouseUp()//　離した時
    {
        rb.isKinematic = false;
    }
}


