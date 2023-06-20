using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;

    Collider RightHandCollider;
    Collider LeftHandCollider;
    Collider RightFootCollider;

    GameObject RightHand;
    GameObject LeftHand;
    GameObject RightFoot;

    GameObject armature, root, hips, spine, chest;
    GameObject shoulderL, upperarmL, lowerarmL;
    GameObject shoulderR, upperarmR, lowerarmR;
    GameObject upperlegR, lowerlegR;

    [Space()]
    public int damage = 10;

    private void Start()
    {
        animator = GetComponent<Animator>();

        FindComponent();

        RightHand = lowerarmR.GetComponent<Transform>().transform.GetChild(0).gameObject;
        RightHandCollider = RightHand.GetComponent<SphereCollider>();

        LeftHand = lowerarmL.GetComponent<Transform>().transform.GetChild(0).gameObject;
        LeftHandCollider = LeftHand.GetComponent<SphereCollider>();

        RightFoot = lowerlegR.GetComponent<Transform>().transform.GetChild(0).gameObject;
        RightFootCollider = RightFoot.GetComponent<SphereCollider>();

        //右手のコライダーを取得
        //RightHandCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
                RightFootCollider.enabled = true;

                //一定時間後にコライダーの機能をオフにする
                Invoke("ColliderReset", 0.3f);
            }
        }
    }

    private void ColliderReset()
    {
        RightHandCollider.enabled = false;
        LeftHandCollider.enabled = false;
        RightFootCollider.enabled = false;
    }

    private void FindComponent()
    {
        armature = transform.GetChild(0).gameObject;
        root = armature.GetComponent<Transform>().transform.GetChild(0).gameObject;
        hips = root.GetComponent<Transform>().transform.GetChild(0).gameObject;
        spine = hips.GetComponent<Transform>().transform.GetChild(1).gameObject;
        chest = spine.GetComponent<Transform>().transform.GetChild(0).gameObject;

        shoulderR = chest.GetComponent<Transform>().transform.GetChild(4).gameObject;
        upperarmR = shoulderR.GetComponent<Transform>().transform.GetChild(0).gameObject;
        lowerarmR = upperarmR.GetComponent<Transform>().transform.GetChild(0).gameObject;

        shoulderL = chest.GetComponent<Transform>().transform.GetChild(3).gameObject;
        upperarmL = shoulderL.GetComponent<Transform>().transform.GetChild(0).gameObject;
        lowerarmL = upperarmL.GetComponent<Transform>().transform.GetChild(0).gameObject;

        upperlegR = hips.GetComponent<Transform>().transform.GetChild(3).gameObject;
        lowerlegR = upperlegR.GetComponent<Transform>().transform.GetChild(0).gameObject;

    }
}
