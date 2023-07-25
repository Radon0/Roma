using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour
{
    public float Hp;
    public float maxHp;
    public bool isDead;
    public Hpui HpuiScript;//
    Animator anim;


    private void Start()
    {
        maxHp = Hp;
        isDead = false;
        anim = gameObject.GetComponent<Animator>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Hp -= 1;
            HpuiScript.HPUI(Hp);
            anim.SetBool("Damage", true);
            Invoke("AnimatorReset", 1.0f);
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AttackEnemy"))
        {
            Hp -= 1;
            HpuiScript.HPUI(Hp);
            anim.SetBool("Damage", true);
            Invoke("AnimatorReset", 1.0f);
        }
        if(other.gameObject.CompareTag("AttackPlayer"))
        {
            Hp -= 1;
            HpuiScript.HPUI(Hp);
            anim.SetBool("Damage", true);
            Invoke("AnimatorReset", 1.0f);
        }
    }
    private void Update()
    {
        if(Hp <= 0)
        {
            isDead = true;
            anim.Play("Death");
        }
    }
    private void AnimatorReset()
    {
        anim.SetBool("Damage", false);
    }
}
