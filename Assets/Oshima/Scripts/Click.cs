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
        rb.isKinematic = true;//リジットボディをの機能をオフ
        defaultPos = transform.position;
        mat = GetComponent<MeshRenderer>().material;
    }
    //　押された時
    private void OnMouseDown()
    {
        mat.color = Color.red;
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
    private void OnMouseOver()    //　上にいる時
    {
        Debug.Log("OnMouseOver");
    }    
    private void OnMouseUp()//　離した時
    {
        rb.isKinematic = false;//リジットボディをオン
    }   
    private void OnMouseUpAsButton() //　オブジェクト上で話した時
    {
        mat.color = Color.gray;
    }
}


