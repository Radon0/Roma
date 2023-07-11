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
    BoxCollider boxCollider = null;
    [SerializeField, Min(0)]
    int maxHp = 3;
    [SerializeField]
    float deadWaitTime = 3;

    //�A�j���[�^�[�̃p�����[�^��ID���擾(�������̂���)
    readonly int SpeedHash = Animator.StringToHash("Speed");
    readonly int AttackHash = Animator.StringToHash("Attack");
    readonly int DeadHash = Animator.StringToHash("Dead");

    public bool isDead = false;
    int EnemyHp = 0;
    Transform thisTransform;

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
        animator.SetBool(DeadHash, true);

        StartCoroutine(nameof(DeadTimer));
    }

    //���S���Ă��琔�b�ԑ҂���
    IEnumerator DeadTimer()
    {
        yield return new WaitForSeconds(deadWaitTime);

        Destroy(gameObject);
    }

    void Move()
    {
        navmeshAgent.SetDestination(target.position);
    }

    //�A�j���[�^�[�̃A�b�v�f�[�g����
    void UpdateAnimator()
    {
        animator.SetFloat(SpeedHash, navmeshAgent.desiredVelocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="AttackEnemy")
        {
            Debug.Log("�E�肪���������I");
        }
    }
}
