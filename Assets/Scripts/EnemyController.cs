using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    Animator animator = null;
    [SerializeField]
    NavMeshAgent navmeshAgent = null;
    [SerializeField]
    Transform target = null;
    [SerializeField]
    CapsuleCollider capsuleCollider = null;
    [SerializeField, Min(0)]
    int maxHp = 3;
    [SerializeField]
    float deadWaitTime = 3;

    //アニメーターのパラメータのIDを取得(高速化のため)
    readonly int SpeedHash = Animator.StringToHash("Speed");
    readonly int AttackHash = Animator.StringToHash("Attack");
    readonly int DeadHash = Animator.StringToHash("Dead");

    bool isDead = false;
    int hp = 0;
    Transform thisTransform;

    public int Hp
    {
        set
        {
            hp = Mathf.Clamp(value, 0, maxHp);
        }
        get
        {
            return hp;
        }
    }

    private void Start()
    {
        thisTransform = transform;  //transformをキャッシュ(高速化)


        InitEnemy();
    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }
        Move();
        UpdateAnimator();
    }

    void InitEnemy()
    {
        Hp = maxHp;
    }

    //被ダメージ処理
    public void Damage(int value)
    {
        if (value <= 0)
        {
            return;
        }

        Hp -= value;
        Debug.Log(Hp);

        if (Hp <= 0)
        {
            Dead();
        }
    }

    //死亡時の処理
    void Dead()
    {
        isDead = true;
        capsuleCollider.enabled = false;
        animator.SetBool(DeadHash, true);

        StartCoroutine(nameof(DeadTimer));
    }

    //死亡してから数秒間待つ処理
    IEnumerator DeadTimer()
    {
        yield return new WaitForSeconds(deadWaitTime);

        Destroy(gameObject);
    }

    void Move()
    {
        navmeshAgent.SetDestination(target.position);
    }

    //アニメーターのアップデート処理
    void UpdateAnimator()
    {
        animator.SetFloat(SpeedHash, navmeshAgent.desiredVelocity.magnitude);
    }
}
