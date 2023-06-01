using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour
{
    public float Hp;    
    bool isDead;
    public GameObject HPObject;//HPuiの参照するゲームオブジェクト
    public Hpui HpuiScript;//

    private void Start()
    {
        isDead = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Hp -= 1;
            HpuiScript.HPUI(Hp);
            Debug.Log("HP = " + Hp);
        }
    }
    private void Update()
    {
        if(Hp<=0)
        {
            isDead = true;
        }
    }
}
