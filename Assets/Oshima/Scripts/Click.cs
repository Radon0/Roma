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

            //Vector3 nowmouseposi;
            //Vector3 diffposi;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            transform.position = ray.GetPoint(80f);

            ////現在のマウスのワールド座標を取得
            //nowmouseposi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //////一つ前のマウス座標との差分を計算して変化量を取得
            //diffposi = nowmouseposi - _nowMousePosi;
            //////開始時のオブジェクトの座標にマウスの変化量を足して新しい座標を設定
            //GetComponent<Transform>().position += diffposi;
            //////現在のマウスのワールド座標を更新
            //_nowMousePosi = nowmouseposi;

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
    //private void OnMouseUpAsButton() //　オブジェクト上ではなした時
    //{
    //}

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    // 押下開始　フラグを立てる
    //    Gmick = false;
    //    // マウスのワールド座標を保存
    //    _nowMousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    // 押下終了　フラグを落とす
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


