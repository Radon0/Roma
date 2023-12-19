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


    //�A�j���[�^�[�̃p�����[�^��ID���擾(�������̂���)
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
        thisTransform = transform;  //transform���L���b�V��(������)
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
    }

    void InitEnemy()
    {
        EnemyHp = maxHp;

    }

    //��_���[�W����
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

    //���S���̏���
    void Dead()
    {
        isDead = true;
        boxCollider.enabled = false;
        animator.SetTrigger(sDownHash);

        StartCoroutine(nameof(DeadTimer));
    }

    //���S���Ă��琔�b�ԑ҂���
    IEnumerator DeadTimer()
    {
        yield return new WaitForSeconds(deadWaitTime);

        Destroy(gameObject);
    }
}
