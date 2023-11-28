using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    Animator animator = null;
    //[SerializeField]
    //NavMeshAgent navmeshAgent = null;
    [SerializeField]
    HPController plyHpController = null;
    //[SerializeField]
    //Transform player = null;
    [SerializeField]
    BoxCollider boxCollider = null;
    [SerializeField, Min(0)]
    int maxHp = 3;
    [SerializeField]
    float deadWaitTime = 3;


    //アニメーターのパラメータのIDを取得(高速化のため)
    //readonly int SpeedHash = Animator.StringToHash("Speed");
    //readonly int AttackHash = Animator.StringToHash("Attack");
    //readonly int DeadHash = Animator.StringToHash("Dead");

    readonly int sJumpHash = Animator.StringToHash("Jamp_Start");
    readonly int eJumpHash = Animator.StringToHash("Jamp_End");
    readonly int sDamage01Hash = Animator.StringToHash("Damage_01_Start");
    readonly int eDamage01Hash = Animator.StringToHash("Damage_01_End");
    readonly int sDamage02Hash = Animator.StringToHash("Damage_02_Start");
    readonly int sDamage03Hash = Animator.StringToHash("Damage_03_Start");
    readonly int sDownHash = Animator.StringToHash("Down_Start");
    readonly int eDownHash = Animator.StringToHash("Down_End");

    public bool isDead = false;
    private int EnemyHp = 0;
    Transform thisTransform;
    HPController HpController;

    private bool isAttacking = false;
    private bool judged = false;


    public int EnemyHpControll
    {
        set
        {
            EnemyHp = Mathf.Clamp(value, 0, maxHp);
        }
        get
        {
            return EnemyHp;
        }
    }

    private void Start()
    {
        thisTransform = transform;  //transformをキャッシュ(高速化)
        HpController = GetComponent<HPController>();
        InitEnemy();
    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }
        if (HpController.Hp > 0)
        {
            //Move();
            //Attack();
        }
        UpdateAnimator();
    }

    void InitEnemy()
    {
        EnemyHp = maxHp;

    }

    //被ダメージ処理
    public void Damage(int value)
    {
        if (value <= 0)
        {
            return;
        }
        
        EnemyHp -= value;
        animator.SetTrigger(sDamage01Hash);

        if (EnemyHp <= 0)
        {
            Dead();
        }
    }

    //死亡時の処理
    void Dead()
    {
        isDead = true;
        boxCollider.enabled = false;
        animator.SetTrigger(sDownHash);

        StartCoroutine(nameof(DeadTimer));
    }

    //死亡してから数秒間待つ処理
    IEnumerator DeadTimer()
    {
        yield return new WaitForSeconds(deadWaitTime);

        Destroy(gameObject);
    }

    //private void Move()
    //{
    //    navmeshAgent.SetDestination(player.position);
    //}

    //アニメーターのアップデート処理
    void UpdateAnimator()
    {
        //animator.SetFloat(SpeedHash, navmeshAgent.desiredVelocity.magnitude);
    }
    //private void Attack()
    //{
    //    if(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
    //    {
    //        if(!judged&&animator.GetCurrentAnimatorStateInfo(0).normalizedTime>=0.4f)
    //        {
    //            if (Vector3.Distance(player.position, thisTransform.position) <= 3f &&
    //                Vector3.Dot(player.position - thisTransform.position, thisTransform.forward) >= 0.7f)
    //            { 
    //                plyHpController.Hp -= 1; 
    //            }
    //        }
    //        if(isAttacking&&animator.GetCurrentAnimatorStateInfo(0).normalizedTime>=0.95f)
    //        {
    //            isAttacking = false;
    //            navmeshAgent.isStopped = false;

    //            StartCoroutine("Groan");
    //        }
    //    }
    //    if(animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
    //    {
    //        if(!isAttacking&&Vector3.Distance(player.position,thisTransform.position)<=2f&&Vector3.Dot(player.position-thisTransform.position,thisTransform.forward)>=0.9f)
    //        {
    //            navmeshAgent.isStopped = true;
    //            isAttacking = true;
    //            judged = false;
    //            animator.SetTrigger("Attack");
    //            StopCoroutine("Groan");
    //        }
    //    }
    //}
    //private IEnumerator Groan()
    //{
    //    yield return new WaitForSeconds(Random.Range(1f, 5f));
    //}
}
