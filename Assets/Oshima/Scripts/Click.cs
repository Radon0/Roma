using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click :MonoBehaviour
{
    private Rigidbody rb;
    public float Readytime;//始まる時間
    public Text ReadyText;//
    [SerializeField] Text EndText;//Ready時間が過ぎた時の文字
    [SerializeField] GameObject Endcall;//Ready時間が過ぎた時のゲームオブジェクト
    private bool Gmick=false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;//リジットボディをの機能をオフ
        Endcall.SetActive(false);
    }
    void Update()
    {
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

    //　押された時
    private void OnMouseDown()
    {
        if (Gmick == false)
        {
            rb.isKinematic = true;
        }
    }
    //　ドラッグされた時
    private void OnMouseDrag()
    {
        if (Gmick == false)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            transform.position = ray.GetPoint(10f);
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
    //private void OnMouseOver()    //　上にいる時
    //{
        
    //}
    private void OnMouseUp()//　離した時
    {
        rb.isKinematic = false;
    }   
    //  private void OnMouseUpAsButton() //　オブジェクト上ではなした時
    //{
      //rb.isKinematic = false;
      //mat.color = Color.gray;
    //}
}


