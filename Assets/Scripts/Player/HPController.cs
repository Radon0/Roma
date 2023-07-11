using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour
{
    public float Hp;    
    public bool isDead;
    public Hpui HpuiScript;//
    Animator anim;

    private void Start()
    {
        isDead = false;
        anim = gameObject.GetComponent<Animator>();
    }

    public void OnCollisionEnter(Collision collision)
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
        if(Hp <= 0)
        {
            isDead = true;
            anim.SetBool("Death", true);
        }
    }

}
