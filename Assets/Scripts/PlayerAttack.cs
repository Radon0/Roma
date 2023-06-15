using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;

    [Header("攻撃時コライダー")]
    //右手のコライダー
    [SerializeField] Collider RightHandCollider;
    //左手のコライダー
    [SerializeField] Collider LeftHandCollider;
    //右足のコライダー
    [SerializeField] Collider RightLegCollider;

    [Space()]
    public int damage = 10;

    private void Start()
    {
        animator = GetComponent<Animator>();

        //右手のコライダーを取得
        //RightHandCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("NormalFrontAttack");

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("NormalFrontAttack"))
            {
                //右手コライダーをオンにする
                RightHandCollider.enabled = true;

                //一定時間後にコライダーの機能をオフにする
                Invoke("ColliderReset", 0.3f);
            }

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("NormalFrontAttack01"))
            {
                //左手コライダーをオンにする
                LeftHandCollider.enabled = true;

                //一定時間後にコライダーの機能をオフにする
                Invoke("ColliderReset", 0.3f);
            }

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("NormalFrontAttack02"))
            {
                //右足コライダーをオンにする
                RightLegCollider.enabled = true;

                //一定時間後にコライダーの機能をオフにする
                Invoke("ColliderReset", 0.3f);
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetBool("Jab", true);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            animator.SetBool("Hikick", true);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            animator.SetBool("Spinkick", true);
        }
    }

    private void ColliderReset()
    {
        RightHandCollider.enabled = false;
        LeftHandCollider.enabled = false;
        RightLegCollider.enabled = false;
    }
}
