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
    [SerializeField]
    private LogInfomation logSystem;//logÉVÉXÉeÉÄ

    readonly int Damage01 = Animator.StringToHash("Damage_01_Trigger");
    readonly int Damage03 = Animator.StringToHash("Damage_03_Trigger");
    readonly int Down = Animator.StringToHash("Down_Trigger");

    bool isHit;

    public GameObject effectPrefab;
    //public ParticleSystem effect;
    public GameObject currentEffect;

    private void Start()
    {
        maxHp = Hp;
        isDead = false;
        isHit = false;
        anim = gameObject.GetComponent<Animator>();
        currentEffect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        currentEffect.SetActive(false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            //logSystem.AddLogText("<color=green>" + gameObject.GetComponent<EnemyInfomation>().EnemyName + "</color>" + "HPîºï™Ç‹Ç≈Ç¢Ç¡ÇΩÇº!!Ç†Ç∆è≠Çµ!!", LogInfomation.LogType.Event);
            //logSystem.AddLogText("<color=green>" + gameObject.GetComponent<PlayerInfomation>().PlayerName + "</color>" + "HPÇ™îºï™ÇµÇ©Ç»Ç¢Çº!!äÎåØ!!", LogInfomation.LogType.Event);
            Hp -= 10;
            HpuiScript.HPUI(Hp);
            anim.SetBool("Damage", true);
            Invoke("AnimatorReset", 1.0f);
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AttackEnemy")&&!isHit)
        {
            Hp -= 5;
            HpuiScript.HPUI(Hp);
            anim.SetTrigger(Damage01);

            isHit = true;
            //if (Hp==5)
            //{
            //    logSystem.AddLogText("<color=green>" + gameObject.GetComponent<EnemyInfomation>().EnemyName + "</color>" + "HPîºï™Ç‹Ç≈Ç¢Ç¡ÇΩÇº!!Ç†Ç∆è≠Çµ!!", LogInfomation.LogType.Event);
            //    logSystem.AddLogText("<color=green>" + gameObject.GetComponent<PlayerInfomation>().PlayerName + "</color>" + "HPÇ™îºï™ÇµÇ©Ç»Ç¢Çº!!äÎåØ!!", LogInfomation.LogType.Event);
            //}

            PlayEffect();
        }
        if(other.gameObject.CompareTag("AttackPlayer")&&!isHit)
        {
            Hp -= 4;
            HpuiScript.HPUI(Hp);
            anim.SetTrigger(Damage01);
            isHit = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("AttackEnemy"))
        {
            isHit = false;
        }
        if (other.gameObject.CompareTag("AttackPlayer"))
        {
            isHit = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AttackEnemy"))
        {
            isHit = false;
        }
        if (other.gameObject.CompareTag("AttackPlayer"))
        {
            isHit = false;
        }
    }
    private void Update()
    {
        if(Hp <= 0&&!isDead)
        {
            //Debug.Log("éÄÇÒÇæ");
            isDead = true;
            //anim.SetTrigger(Down);
            return;
        }
    }

    //void GenerateEffect()
    //{
    //    GameObject effect = Instantiate(attackEffect) as GameObject;
    //    effect.transform.position = rightHand.transform.position;

    //    //ParticleSystem newParticle = Instantiate(effect);
    //    //newParticle.transform.position = rightHand.transform.position;
    //    //newParticle.Play();
    //    //Destroy(newParticle.gameObject, 1.5f);
    //}

    public void PlayEffect()
    {
        currentEffect.SetActive(true);
    }
}
