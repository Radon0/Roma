using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;

    //�E��̃R���C�_�[
    public Collider RightHandCollider;

    EnemyController e;

    int damage;

    private void Start()
    {
        animator = GetComponent<Animator>();

        //�E��̃R���C�_�[���擾
        //RightHandCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetBool("NormalFrontAttack", true);
            damage = 5;

            //�E��R���C�_�[���I���ɂ���
            RightHandCollider.enabled = true;

            e.Damage(damage);

            //��莞�Ԍ�ɃR���C�_�[�̋@�\���I�t�ɂ���
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
