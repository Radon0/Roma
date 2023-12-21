using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackKari : MonoBehaviour
{
    Animator animator;

    bool combo1enable;
    bool combo2enable;
    bool combocombo = true;
    bool cancombo = false;
    [Header("コンボ出す時間")]
    [SerializeField] float combo1time;
    [SerializeField] float combo2time;
    [SerializeField] float combo3time;

    Collider RightHandCollider;
    Collider LeftHandCollider;
    Collider RightFootCollider;

    public GameObject RightHand;
    public GameObject LeftHand;
    public GameObject RightFoot;
        

    void Start()
    {
        animator = GetComponent<Animator>();

        RightHandCollider = RightHand.GetComponent<SphereCollider>();
        LeftHandCollider = LeftHand.GetComponent<SphereCollider>();
        RightFootCollider = RightFoot.GetComponent<SphereCollider>();
    }

    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            animator.SetBool("AttackUp", true);

            RightFootCollider.enabled = true;
            Invoke("ColliderReset", 0.1f);
            Invoke("AnimStop", 0.5f);
        }

        if(Input.GetMouseButtonDown(0) && !cancombo && !combo1enable && !combo2enable)
        { cancombo = true; }

        if(cancombo&&!combo1enable&&combocombo)
        {
            //入力したら一定期間入力を受け付け、入力があったらコンボ２へ移行、なかったらキャンセル
            //コンボ１
            animator.SetBool("combo1", true);
            //Debug.Log("コンボ１");

            //右手コライダーをオンにする
            RightHandCollider.enabled = true;

            //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset", 0.1f);

            combo1time += Time.deltaTime;
            if (combo1time > 0.1 && combo1time < 0.75)
            {
                //入力受付期間
                if (Input.GetMouseButtonDown(0))
                {
                    combo1time = 0;

                    combo1enable = false;
                    combo1enable = true;
                    combocombo = false;
                    //タイマーを初期化し、コンボ１をオフにして、コンボ２をTrueにする
                }
            }
            if (combo1time > 0.75)
            {
                //入力されなかったときの処理
                StartCoroutine("cancombocorutine");
                //StartCoroutine("cancomboenable");
            }
        }

        if (combo1enable)
        {
            //Debug.Log("コンボ２");
            //コンボ２
            animator.SetBool("combo2", true);

            //左手コライダーをオンにする
            LeftHandCollider.enabled = true;

            //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset", 0.1f);

            combo2time += Time.deltaTime;
            if (combo2time < 0.75 && combo2time > 0.1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    combo2time = 0;
                    combo2enable = true;
                    combo1enable = false;
                }
            }
            if (combo2time > 0.75)
            {
                combo1enable = false;
                StartCoroutine("cancombocorutine");

            }

        }

        if (combo2enable)
        {
            //Debug.Log("コンボ３");
            //コンボ３
            animator.SetBool("combo3", true);

            //右足コライダーをオンにする
            RightFootCollider.enabled = true;

            //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset", 0.1f);

            combo3time += Time.deltaTime;
            if (combo3time > 0.75)
            {
                StartCoroutine("cancombocorutine");
                combo2enable = false;
            }
        }
    }

    IEnumerator cancombocorutine()
    {

        Debug.Log("コンボ終了");
        cancombo = false;
        combocombo = false;
        combo1enable = false;
        combo2enable = false;
        AttackReset();
        yield return new WaitForSeconds(0.5f);
        combocombo = true;
    }

    void AttackReset()
    {
        animator.SetBool("combo1", false);
        animator.SetBool("combo2", false);
        animator.SetBool("combo3", false);
        combo1time = 0;
        combo2time = 0;
        combo3time = 0;
    }

    private void ColliderReset()
    {
        RightHandCollider.enabled = false;
        LeftHandCollider.enabled = false;
        RightFootCollider.enabled = false;
    }

    private void AnimStop()
    {
        animator.SetBool("AttackUp", false);
    }
}