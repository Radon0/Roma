using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    //private Material mat;
   // public BoxCollider Box;
    private Rigidbody rb;
    //public float Readytime;//始まる時間
    //public Text ReadyText;//
    //[SerializeField] Text EndText;//Ready時間が過ぎた時の文字
    //[SerializeField] GameObject Endcall;//Ready時間が過ぎた時のゲームオブジェクト
    private void Start()
    {
       // Box = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;//リジットボディをの機能をオフ
        //Endcall.SetActive(false);
        //ReadyText = GetComponent<Text>();
    }
    //void Update()
    //{
    //    if (1 < Readytime)
    //    {
    //        Readytime -= Time.deltaTime;
    //        ReadyText.text = Readytime.ToString("0");//改行するための空白けさないで
    //    }
    //    else if (Readytime <= 1f)
    //    {
    //        Destroy(ReadyText);
    //        Endcall.SetActive(true);
    //        EndText.text = "終了!!";
    //        Destroy(EndText, 2f);

    //    }
    //}

    //　押された時
    private void OnMouseDown()
    {
        rb.isKinematic = true;
    }
    //　ドラッグされた時
    private void OnMouseDrag()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.position = ray.GetPoint(10f);
    }
    private void OnMouseEnter()//　入ってきた時
    {
        transform.localScale *= 1.5f;
    }
    private void OnMouseExit()  //　出ていったとき
    {
        transform.localScale /= 1.5f;
    }
    //private void OnMouseOver()    //　上にいる時
    //{
        
    //}
    private void OnMouseUp()//　離した時
    {
       // Box.enabled = false;
        rb.isKinematic = false;//リジットボディをオン
    }   
    //  private void OnMouseUpAsButton() //　オブジェクト上ではなした時
    //{
      //rb.isKinematic = false;
      //mat.color = Color.gray;
    //}
}


