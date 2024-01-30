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

    readonly int Run = Animator.StringToHash("Run");
    readonly int Punch01 = Animator.StringToHash("Punch_01_Trigger");
    readonly int Damage01 = Animator.StringToHash("Damage_01_Trigger");
    readonly int Damage02 = Animator.StringToHash("Damage_02_Trigger");
    readonly int Damage03 = Animator.StringToHash("Damage_03_Trigger");
    readonly int Down = Animator.StringToHash("Down_Trigger");

    public float attackCoolDown = 1.0f;
    private float timeSinceLastAttack = 0.0f;
    private bool canAttack = true;

    private AudioSource punchAudio;

    //HP
    private float enemyHp = 0.0f;
    private bool deathCheck = false;

    private GameObject ply;
    FPSController fpsController;

    //Dead
    private Rigidbody rigid;

    // Use this for initialization

    void Start()
    {
        enemyController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        setPosition = GetComponent<SetPosition>();
        rigid = GetComponent<Rigidbody>();
        punchAudio.Play();
        velocity = Vector3.zero;
        arrived = false;
        elapsedTime = 0f;
        SetState(EnemyState.Walk);
        rightHandCollider.enabled = false;
        enemyHp = hpController.Hp;

        ply = GameObject.Find("Player1");
        fpsController = ply.GetComponent<FPSController>();
        deathCheck = fpsController.isDead;
    }

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
        float readyTime = Ready.Instance.Readytime;
        if (enemyHp <= 0)
        {
            if (!isDead)
            {
                isDead = true;
                animator.SetTrigger(Down);
                SetState(EnemyState.Dead);
                rigid.isKinematic=true;
            }
            return;
        }
        else if (readyTime > 1)
        {
            //animator.Play("C_Wait");
            rigid.isKinematic = true;
            SetState(EnemyState.Wait);
        }
        else if(deathCheck)
        {
            rigid.isKinematic = false;
            SetState(EnemyState.Wait);
        }
        else
        {
            rigid.isKinematic = false;
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
            //if (enemyController.isGrounded)
            //{
               velocity = Vector3.zero;
               animator.SetTrigger(Run);
               direction = (setPosition.GetDestination() - transform.position).normalized;
               transform.LookAt(new Vector3(setPosition.GetDestination().x, transform.position.y, setPosition.GetDestination().z));
               velocity = direction * walkSpeed;
            //}
            //�@�ړI�n�ɓ����������ǂ����̔���
            if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 3.0f )
            {
                SetState(EnemyState.Wait);
                velocity = Vector3.zero;
                if (canAttack)
                {
                    SetState(EnemyState.Attack);
                    animator.SetTrigger(Punch01);
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
            animator.Play("C_wait");
            arrived = true;
            velocity = Vector3.zero;
        }
        else if(tempState==EnemyState.Dead)
        {
            isDead = true;
            state = tempState;
            arrived = true;
            velocity = Vector3.zero;
            animator.SetTrigger(Down);
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
        //punchAudio.Stop();
        SetState(EnemyState.Wait);
    }

    private IEnumerator StanTimer()
    {
        yield return new WaitForSeconds(1.5f);
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
        animator.SetTrigger(Damage01);

    }

    //���S���̏���
    private IEnumerator Dead()
    {
        isDead = true;
        boxCollider.enabled = false;
        animator.SetTrigger(Damage02);
        yield return new WaitForSeconds(1f);
        animator.SetTrigger(Damage03);
        yield return new WaitForSeconds(1f);
        animator.SetTrigger(Down);

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
