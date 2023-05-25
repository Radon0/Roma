using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    #region 変数
    float x, z;
    public float speed = 0.1f;
    private float currentSpeed;
    public float dashSpeed;
    private int dashForce = 3;

    private Rigidbody rb;
    private int upForce = 300;
    private bool isGround;

    private Animator anim;

    public GameObject fpscam , tpscam;
    Quaternion fpscameraRot, tpscameraRot, characterRot;
    public float Xsensityvity = 3f, Ysensityvity = 3f;

    bool cursorLock = true;

    //変数の宣言（角度の制限用）
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
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

        fpscameraRot *= Quaternion.Euler(-yRot, 0, 0);
        tpscameraRot *= Quaternion.Euler(-yRot, 0, 0);
        characterRot *= Quaternion.Euler(0, xRot, 0);

        //Updateの中で作成した関数を呼ぶ
        fpscameraRot = ClampRotation(fpscameraRot);
        tpscameraRot = ClampRotation(tpscameraRot);

        fpscam.transform.localRotation = fpscameraRot;
        tpscam.transform.localRotation = tpscameraRot;
        transform.localRotation = characterRot;

        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(new Vector3(0, upForce, 0));
        }

        //ダッシュ
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = dashSpeed;
            anim.SetBool("Run", true);
            anim.SetBool("Wark", false);
        }
        else
        {
            currentSpeed = speed;
            anim.SetBool("Run", false);
        }

        //攻撃
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("Attack", true);
        }

        UpdateCursorLock();

        CameraChange();
    }

    private void FixedUpdate()
    {
        x = 0;
        z = 0;

        x = Input.GetAxisRaw("Horizontal") * currentSpeed;
        z = Input.GetAxisRaw("Vertical") * currentSpeed;

        if (x != 0 || z != 0)
        {
            anim.SetBool("Walk", true);
        }

        transform.position += this.transform.forward * z + this.transform.transform.right * x;
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

    //角度制限関数の作成
    public Quaternion ClampRotation(Quaternion q)
    {
        //q=x,y,z,w(x,y,zはベクトル(量と向き)：wはスカラー(座標とは無関係の量)）

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
        if(Input.GetKeyDown(KeyCode.P))
        {
            tpscam.gameObject.SetActive(true);
            fpscam.gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            fpscam.gameObject.SetActive(true);
            tpscam.gameObject.SetActive(false);        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "ground")
        {
            isGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "ground")
            isGround = false;
    }
}
