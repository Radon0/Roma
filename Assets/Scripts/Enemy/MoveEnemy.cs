using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{

    public enum EnemyState
    {
        Walk,
        Wait,
        Chase,
        Attack,
        Damage,
        Dead
    };

    private CharacterController enemyController;
    private Animator animator;
    //�@�ړI�n
    private Vector3 destination;
    //�@�����X�s�[�h
    [SerializeField]
    private float walkSpeed = 1.0f;
    //�@���x
    private Vector3 velocity;
    //�@�ړ�����
    private Vector3 direction;
    //�@�����t���O
    private bool arrived;
    //�@SetPosition�X�N���v�g
    private SetPosition setPosition;
    //�@�҂�����
    [SerializeField]
    private float waitTime = 0.5f;
    //�@�o�ߎ���
    private float elapsedTime;
    // �G�̏��
    private EnemyState state;
    //�@�v���C���[Transform
    private Transform playerTransform;
    //�G��BoxCollider
    [SerializeField]
    BoxCollider boxCollider = null;
    //deadWaitTimer
    [SerializeField]
    float deadWaitTime = 3.0f;

    public HPController hpController;
    public bool isDead = false;

    public SphereCollider rightHandCollider;

    readonly int sRunHash = Animator.StringToHash("Run_Start");
    readonly int eRunHash = Animator.StringToHash("Run_End");
    readonly int sPunch01Hash = Animator.StringToHash("Punch_01_Start");
    readonly int ePunch01Hash = Animator.StringToHash("Punch_01_End");
    readonly int sJumpHash = Animator.StringToHash("Jamp_Start");
    readonly int eJumpHash = Animator.StringToHash("Jamp_End");
    readonly int sDamage01Hash = Animator.StringToHash("Damage_01_Start");
    readonly int eDamage01Hash = Animator.StringToHash("Damage_01_End");
    readonly int sDamage02Hash = Animator.StringToHash("Damage_02_Start");
    readonly int sDamage03Hash = Animator.StringToHash("Damage_03_Start");
    readonly int sDownHash = Animator.StringToHash("Down_Start");
    readonly int eDownHash = Animator.StringToHash("Down_End");

    public float attackCoolDown = 1.0f;
    private float timeSinceLastAttack = 0.0f;
    private bool canAttack = true;

    private AudioSource punchAudio;

    //HP
    private float enemyHp = 0.0f;
    private bool deathCheck = false;

    // Use this for initialization

    void Start()
    {
        enemyController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        setPosition = GetComponent<SetPosition>();
        punchAudio.Play();
        velocity = Vector3.zero;
        arrived = false;
        elapsedTime = 0f;
        SetState(EnemyState.Walk);
        rightHandCollider.enabled = false;
        enemyHp = hpController.Hp;
    }

    //private void FixedUpdate()
    //{
    //    if(isDead)
    //    {
    //        Debug.Log("����");
    //        return;
    //    }
    //}
    // Update is called once per frame
    void Update()
    {
        enemyHp = hpController.Hp;
        //if(!canAttack)
        //{
        //    timeSinceLastAttack += Time.deltaTime;
        //    if(timeSinceLastAttack>=attackCoolDown)
        //    {
        //        canAttack = true;
        //        timeSinceLastAttack = 0.0f;
        //    }
        //}
        Debug.Log(walkSpeed);
        Debug.Log(state);
        float readyTime = Ready.Instance.Readytime;
        if (readyTime > 1)
        {
            SetState(EnemyState.Wait);
        }
        else if (enemyHp <= 0)
        {
            if (!isDead)
                isDead = true;
                SetState(EnemyState.Dead);
        }
        else
        {
            SetState(EnemyState.Walk);
        }
        //�@�����܂��̓L�����N�^�[��ǂ���������
        if (state == EnemyState.Walk || state == EnemyState.Chase)
        {
            //�@�L�����N�^�[��ǂ��������Ԃł���΃L�����N�^�[�̖ړI�n���Đݒ�
            if (state == EnemyState.Chase)
            {
                setPosition.SetDestination(playerTransform.position);
            }
            if (enemyController.isGrounded)
            {
               velocity = Vector3.zero;
               animator.SetTrigger(sRunHash);
               direction = (setPosition.GetDestination() - transform.position).normalized;
               transform.LookAt(new Vector3(setPosition.GetDestination().x, transform.position.y, setPosition.GetDestination().z));
               velocity = direction * walkSpeed;
            }

            //�@�ړI�n�ɓ����������ǂ����̔���
            if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 3.0f && canAttack)
            {
                Debug.Log(Vector3.Distance(transform.position, setPosition.GetDestination()));
                SetState(EnemyState.Wait);
                velocity = Vector3.zero;
                walkSpeed = 0;
                animator.SetTrigger(eRunHash);
                if (velocity.x<0.3f)
                {
                    SetState(EnemyState.Attack);
                    animator.SetTrigger(sPunch01Hash);
                    //punchAudio.PlayOneShot(punchAudio.clip);
                    rightHandCollider.enabled = true;
                    Invoke("ColliderReset", 1.0f);
                    canAttack = false;

                    StartCoroutine(StanTimer());
                }
            }
        }
        //�@�������Ă������莞�ԑ҂�
        else if (state == EnemyState.Wait)
        {
            elapsedTime += Time.deltaTime;

            //�@�҂����Ԃ��z�����玟�̖ړI�n��ݒ�
            if (elapsedTime > waitTime)
            {
                SetState(EnemyState.Walk);
            }
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        enemyController.Move(velocity * Time.deltaTime);
    }

    //�@�G�L�����N�^�[�̏�ԕύX���\�b�h
    public void SetState(EnemyState tempState, Transform targetObj = null)
    {
        if (tempState == EnemyState.Walk)
        {
            arrived = false;
            elapsedTime = 0f;
            state = tempState;
        }
        else if (tempState == EnemyState.Chase)
        {
            state = tempState;
            //�@�ҋ@��Ԃ���ǂ�������ꍇ������̂�Off
            arrived = false;
            //�@�ǂ�������Ώۂ��Z�b�g
            playerTransform = targetObj;
        }
        else if (tempState == EnemyState.Wait)
        {
            state = tempState;
            arrived = true;
            velocity = Vector3.zero;
            animator.SetTrigger(eRunHash);
        }
        else if(tempState==EnemyState.Dead)
        {
            isDead = true;
            state = tempState;
            arrived = true;
            velocity = Vector3.zero;
            //StartCoroutine(Dead());
            animator.SetBool("Dead", true);
        }
    }

    public EnemyState GetState()
    {
        return state;
    }

    private void ColliderReset()
    {
        //Debug.Log(rightHandCollider.enabled);
        rightHandCollider.enabled = false;
        animator.SetTrigger(ePunch01Hash);
        //punchAudio.Stop();
        SetState(EnemyState.Wait);
    }

    private IEnumerator StanTimer()
    {
        yield return new WaitForSeconds(1);
        canAttack = true;
    }

    //��_���[�W����
    public void Damage(int value)
    {
        if (value <= 0)
        {
            return;
        }

        enemyHp -= value;
        animator.SetTrigger(sDamage01Hash);

    }

    //���S���̏���
    private IEnumerator Dead()
    {
        isDead = true;
        boxCollider.enabled = false;
        animator.SetTrigger(sDamage02Hash);
        yield return new WaitForSeconds(1f);
        animator.SetTrigger(sDamage03Hash);
        yield return new WaitForSeconds(1f);
        animator.SetTrigger(sDownHash);

        //StartCoroutine(nameof(DeadTimer));
    }
    //public void DamageAnimation02End()
    //{
    //    animator.SetTrigger(sDamage03Hash);
    //}
    //public void DamageAnimation03End()
    //{
    //    animator.SetTrigger(sDownHash);
    //}

    //���S���Ă��琔�b�ԑ҂���
    //IEnumerator DeadTimer()
    //{
    //    yield return new WaitForSeconds(deadWaitTime);

    //    Destroy(gameObject);
    //}
}
