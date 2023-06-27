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
        rb.isKinematic = true;//リジットボディをの機能をオフ       
    }
   
    
    //　押された時
    private void OnMouseDown()
    {
        if (Gimick == false)
        {
            rb.isKinematic = true;
        }
    }
    //　ドラッグされた時
    private void OnMouseDrag()
    {
        if (Gimick == false)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            transform.position = ray.GetPoint(10f);
        }
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
        Gimick = true;
        // Box.enabled = false;
        rb.isKinematic = false;//リジットボディをオン
    }   
    //  private void OnMouseUpAsButton() //　オブジェクト上ではなした時
    //{
      //rb.isKinematic = false;
      //mat.color = Color.gray;
    //}
}


