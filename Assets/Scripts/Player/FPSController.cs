using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    #region �ϐ�
    public float playerX;
    public float playerZ;
    public float speed = 0.1f;
    public float dashSpeed;
    public int jumpForce = 300;

    private Rigidbody rb;
    private Animator anim;
    private Ready ready;
    private float currentSpeed;
    private bool isGround;
    private bool canDash = false;


    public GameObject fpscam , tpscam;
    Quaternion fpscameraRot, tpscameraRot, characterRot;
    public float Xsensityvity = 3f, Ysensityvity = 3f;

    bool cursorLock = true;

    //�ϐ��̐錾�i�p�x�̐����p�j
    float minX = -90f, maxX = 90f;

    HPController HpController;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        fpscameraRot = fpscam.transform.localRotation;
        tpscameraRot = tpscam.transform.localRotation;
        characterRot = transform.localRotation;
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        HpController = GetComponent<HPController>();
    }

    // Update is called once per frame
    void Update()
    {
        float readyTime = Ready.Instance.Readytime;
        if (HpController.Hp > 0 && readyTime <= 1)
        {
            //Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);
            float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
            float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

            fpscameraRot *= Quaternion.Euler(-yRot, 0, 0);
            tpscameraRot *= Quaternion.Euler(-yRot, 0, 0);
            characterRot *= Quaternion.Euler(0, xRot, 0);

            //Update�̒��ō쐬�����֐����Ă�
            fpscameraRot = ClampRotation(fpscameraRot);
            tpscameraRot = ClampRotation(tpscameraRot);

            fpscam.transform.localRotation = fpscameraRot;
            tpscam.transform.localRotation = tpscameraRot;
            transform.localRotation = characterRot;

            //�W�����v
            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                anim.SetBool("Run", false);
                anim.SetBool("Walk", false);
                rb.AddForce(new Vector3(0, jumpForce, 0));
                anim.SetBool("Jump",true);
                isGround = false;
            }

            //�_�b�V��
            if (Input.GetKey(KeyCode.LeftShift) && canDash == true)
            {
                currentSpeed = dashSpeed;
                anim.SetBool("Run", true);
                //anim.SetBool("Walk", false);
            }
            else
            {
                currentSpeed = speed;
                anim.SetBool("Run", false);
            }

            //�U��
            //if (Input.GetKeyDown(KeyCode.Mouse0))
            //{
            //    anim.SetBool("Attack", true);
            //}

            UpdateCursorLock();

            CameraChange();
        }
    }

    private void FixedUpdate()
    {
        if (HpController.Hp > 0)
        {
            playerX = 0;
            playerZ = 0;

            canDash = false;

            playerX = Input.GetAxisRaw("Horizontal") * currentSpeed;
            playerZ = Input.GetAxisRaw("Vertical") * currentSpeed;


            if (playerX != 0 || playerZ != 0)
            {
                anim.SetBool("Walk", true);
                if (playerX != 0 && playerZ == 0)
                {
                    anim.SetBool("Walk", false);
                    anim.SetBool("WalkSide", true);
                }
                else if (playerX == 0 && playerZ < 0)
                {
                    anim.SetBool("Walk", false);
                    anim.SetBool("WalkSide", false);
                    anim.SetBool("WalkBack", true);
                }
                else if (playerX == 0 && playerZ > 0)
                {
                    anim.SetBool("WalkBack", true);
                    canDash = true;
                }
                else
                {
                    anim.SetBool("WalkBack", false);
                    if (playerX != 0 && playerZ > 0)
                    {
                        anim.SetBool("WalkSide", false);
                        canDash = true;
                    }
                }
            }
            else
            {
                anim.SetBool("Walk", false);
                anim.SetBool("WalkSide", false);
                anim.SetBool("WalkBack", false);
            }

            if (playerX != 0 && playerZ != 0)
            {
                playerX /= 1.41421356f;
                playerZ /= 1.41421356f;
            }

            transform.position += this.transform.forward * playerZ + this.transform.transform.right * playerX;
        }
    }

    public void UpdateCursorLock()
    { 
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if(Input.GetMouseButton(0))
        {
            cursorLock = true;
        }


        if(cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //�p�x�����֐��̍쐬
    public Quaternion ClampRotation(Quaternion q)
    {
        //q=x,y,z,w(x,y,z�̓x�N�g��(�ʂƌ���)�Fw�̓X�J���[(���W�Ƃ͖��֌W�̗�)�j

        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX, minX, maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }

    public void CameraChange()
    {
        //��l�̎��_����O�l�̎��_�̐؂�ւ�
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (fpscam.gameObject.activeSelf==true)
            {
                fpscam.gameObject.SetActive(false);
                tpscam.gameObject.SetActive(true);
            }
            else
            {
                tpscam.gameObject.SetActive(false);
                fpscam.gameObject.SetActive(true);
            }
        }
    }

    //�v���C���[�̑����ɂ���SphereCollider�Ŕ��������Ă���
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = true;
            //Debug.Log("�������Ă���");
            anim.SetBool("Jump",false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = false;
            //Debug.Log("�������Ă��Ȃ�");
        }
    }
}
