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
    //敵のBoxCollider
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
        //　見回りまたはキャラクターを追いかける状態
        if (state == EnemyState.Walk || state == EnemyState.Chase)
        {
            //　キャラクターを追いかける状態であればキャラクターの目的地を再設定
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
            //　目的地に到着したかどうかの判定
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

    //被ダメージ処理
    public void Damage(int value)
    {
        if (value <= 0)
        {
            return;
        }

        enemyHp -= value;
        animator.SetTrigger(Damage01);

    }

    //死亡時の処理
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

    //死亡してから数秒間待つ処理
    //IEnumerator DeadTimer()
    //{
    //    yield return new WaitForSeconds(deadWaitTime);

    //    Destroy(gameObject);
    //}
}
