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
    //　目的地
    private Vector3 destination;
    //　歩くスピード
    [SerializeField]
    private float walkSpeed = 1.0f;
    //　速度
    private Vector3 velocity;
    //　移動方向
    private Vector3 direction;
    //　到着フラグ
    private bool arrived;
    //　SetPositionスクリプト
    private SetPosition setPosition;
    //　待ち時間
    [SerializeField]
    private float waitTime = 0.5f;
    //　経過時間
    private float elapsedTime;
    // 敵の状態
    private EnemyState state;
    //　プレイヤーTransform
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
    //        Debug.Log("死んだ");
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
        //　見回りまたはキャラクターを追いかける状態
        if (state == EnemyState.Walk || state == EnemyState.Chase)
        {
            //　キャラクターを追いかける状態であればキャラクターの目的地を再設定
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

            //　目的地に到着したかどうかの判定
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
        //　到着していたら一定時間待つ
        else if (state == EnemyState.Wait)
        {
            elapsedTime += Time.deltaTime;

            //　待ち時間を越えたら次の目的地を設定
            if (elapsedTime > waitTime)
            {
                SetState(EnemyState.Walk);
            }
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        enemyController.Move(velocity * Time.deltaTime);
    }

    //　敵キャラクターの状態変更メソッド
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
            //　待機状態から追いかける場合もあるのでOff
            arrived = false;
            //　追いかける対象をセット
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

    //被ダメージ処理
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
    //　敵キャラクターの状態取得メソッド
    //死亡時の処理
    //void Dead()
    //{
    //    isDead = true;
    //    //boxCollider.enabled = false;
    //    //animator.SetBool(DeadHash, true);

    //}
}
