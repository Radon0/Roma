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
        Attack
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

    public HPController hpController;
    public bool isDead = false;

    private int maxHp = 10;
    private int EnemyHp = 0;

    public SphereCollider rightHandCollider;

    readonly int sRunHash = Animator.StringToHash("Run_Start");
    readonly int eRunHash = Animator.StringToHash("Run_End");
    readonly int sPunch01Hash = Animator.StringToHash("Punch_01_Start");
    readonly int ePunch01Hash = Animator.StringToHash("Punch_01_End");

    public float attackCoolDown = 1.0f;
    private float timeSinceLastAttack = 0.0f;
    private bool canAttack = true;

    private AudioSource punchAudio;

    // Use this for initialization

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
        if(!canAttack)
        {
            timeSinceLastAttack += Time.deltaTime;
            if(timeSinceLastAttack>=attackCoolDown)
            {
                canAttack = true;
                timeSinceLastAttack = 0.0f;
            }
        }

        float readyTime = Ready.Instance.Readytime;
        if (readyTime > 1)
        {
            SetState(EnemyState.Wait);
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
                SetState(EnemyState.Wait);
                animator.SetTrigger(eRunHash);
                if (velocity.x>0.1f&&velocity.x<0.3f)
                {
                    SetState(EnemyState.Attack);
                    animator.SetTrigger(sPunch01Hash);
                    GetComponent<AudioSource>().Play();
                    rightHandCollider.enabled = true;
                    Invoke("ColliderReset", 1.0f);
                    canAttack = false;
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
            elapsedTime = 0f;
            state = tempState;
            arrived = true;
            velocity = Vector3.zero;
            animator.SetTrigger(eRunHash);
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
        GetComponent<AudioSource>().Stop();
        SetState(EnemyState.Wait);
    }

    private void avoidMethod()
    {
        
    }

    //��_���[�W����
    //public void Damage(int value)
    //{
    //    if (value <= 0)
    //    {
    //        return;
    //    }

    //    EnemyHp -= value;

    //    if (EnemyHp <= 0)
    //    {
    //        Dead();
    //    }
    //}
    //�@�G�L�����N�^�[�̏�Ԏ擾���\�b�h
    //���S���̏���
    //void Dead()
    //{
    //    isDead = true;
    //    //boxCollider.enabled = false;
    //    //animator.SetBool(DeadHash, true);

    //}
}
