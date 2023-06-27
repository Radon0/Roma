using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    #region �ϐ�
    float x, z;
    public float speed = 0.1f;
    private float currentSpeed;
    public float dashSpeed;
    //private int dashForce = 3;

    private Rigidbody rb;
    public int jumpForce = 300;
    private bool isGround;
    //private bool isJump;
    private bool canDash = false;

    private Animator anim;

    public GameObject fpscam , tpscam;
    Quaternion fpscameraRot, tpscameraRot, characterRot;
    public float Xsensityvity = 3f, Ysensityvity = 3f;

    bool cursorLock = true;

    //�ϐ��̐錾�i�p�x�̐����p�j
    float minX = -90f, maxX = 90f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        fpscameraRot = fpscam.transform.localRotation;
        tpscameraRot = tpscam.transform.localRotation;
        characterRot = transform.localRotation;
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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

    private void FixedUpdate()
    {
        x = 0;
        z = 0;

        canDash = false;

        x = Input.GetAxisRaw("Horizontal") * currentSpeed;
        z = Input.GetAxisRaw("Vertical") * currentSpeed * 0.8f;


        if (x != 0 || z != 0)
        {
            anim.SetBool("Walk", true);
            if (x != 0 && z == 0)
            {
                anim.SetBool("Walk", false);
                anim.SetBool("WalkSide", true);
                Debug.Log("���ɕ���");
            }
            else if (x == 0 && z < 0)
            {
                anim.SetBool("Walk", false);
                anim.SetBool("WalkBack", true);
                Debug.Log("���ɕ���");
            }
            else if (x == 0 && z > 0)
            {
                //anim.SetBool("Walk", false);
                canDash = true;
                Debug.Log("�O�ɕ���");
            }
        }
        else
        {
            Debug.Log("�~�܂���");
            anim.SetBool("Walk", false);
            anim.SetBool("WalkSide", false);
            anim.SetBool("WalkBack", false);
        }

        if (x != 0 && z != 0)
        {
            x /= 1.41421356f;
            z /= 1.41421356f;
        }

        transform.position += this.transform.forward * z * 0.8f + this.transform.transform.right * x;
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
            tpscam.gameObject.SetActive(true);
            fpscam.gameObject.SetActive(false);
        }
        //�O�l�̎��_�����l�̎��_�̐؂�ւ�
        if(Input.GetKeyDown(KeyCode.L))
        {
            fpscam.gameObject.SetActive(true);
            tpscam.gameObject.SetActive(false);        }
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
