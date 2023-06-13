using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;

    //右手のコライダー
    public Collider RightHandCollider;

    EnemyController e;

    int damage;

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
            animator.SetBool("NormalFrontAttack", true);
            damage = 5;

            //右手コライダーをオンにする
            RightHandCollider.enabled = true;

            e.Damage(damage);

            //一定時間後にコライダーの機能をオフにする
            Invoke("ColliderReset", 0.3f);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            animator.SetBool("NormalFrontAttack", false);
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
    }
}
