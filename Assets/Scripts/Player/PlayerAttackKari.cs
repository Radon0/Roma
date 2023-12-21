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
    [Header("�R���{�o������")]
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
            //���͂���������ԓ��͂��󂯕t���A���͂���������R���{�Q�ֈڍs�A�Ȃ�������L�����Z��
            //�R���{�P
            animator.SetBool("combo1", true);
            //Debug.Log("�R���{�P");

            //�E��R���C�_�[���I���ɂ���
            RightHandCollider.enabled = true;

            //��莞�Ԍ�ɃR���C�_�[�̋@�\���I�t�ɂ���
            Invoke("ColliderReset", 0.1f);

            combo1time += Time.deltaTime;
            if (combo1time > 0.1 && combo1time < 0.75)
            {
                //���͎�t����
                if (Input.GetMouseButtonDown(0))
                {
                    combo1time = 0;

                    combo1enable = false;
                    combo1enable = true;
                    combocombo = false;
                    //�^�C�}�[�����������A�R���{�P���I�t�ɂ��āA�R���{�Q��True�ɂ���
                }
            }
            if (combo1time > 0.75)
            {
                //���͂���Ȃ������Ƃ��̏���
                StartCoroutine("cancombocorutine");
                //StartCoroutine("cancomboenable");
            }
        }

        if (combo1enable)
        {
            //Debug.Log("�R���{�Q");
            //�R���{�Q
            animator.SetBool("combo2", true);

            //����R���C�_�[���I���ɂ���
            LeftHandCollider.enabled = true;

            //��莞�Ԍ�ɃR���C�_�[�̋@�\���I�t�ɂ���
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
            //Debug.Log("�R���{�R");
            //�R���{�R
            animator.SetBool("combo3", true);

            //�E���R���C�_�[���I���ɂ���
            RightFootCollider.enabled = true;

            //��莞�Ԍ�ɃR���C�_�[�̋@�\���I�t�ɂ���
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

        Debug.Log("�R���{�I��");
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