using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public bool stop=false;
    public GameObject ShellPrefab;

    public float MaxTime;
    [SerializeField]
    [Tooltip("対象物(向く方向)")]
    private GameObject target;

    [SerializeField]
    [Tooltip("対象物を向くまでのスピード[0-1](値が小さいほど向くまでのスピードが遅い")]
    private float speed;
    
    //public AudioClip sound;
    public int count;
    void Update()
    {
        count += 1;
        if (count == 1000&&stop==false)
        //発射間隔F
        {
            Vector3 spawnPosition = transform.position + new Vector3(0, 3f, 0);
            GameObject Shell = Instantiate(ShellPrefab, spawnPosition, Quaternion.identity);
            Rigidbody shellRb = Shell.GetComponent<Rigidbody>();
            stop=true;
            shellRb.AddForce(transform.forward * 1300);

            //弾速設定
            count=0;
            //AudioSource.PlayClipAtPoint(sound, transform.position);

            Destroy(Shell, 5.0f);
            //弾を撃った後に破壊するF 上手くいかないのでShellDestroyを作成
        }

        if (stop == false)
        {

            // 対象物と自分自身の座標からベクトルを算出してQuaternion(回転値)を取得
            Vector3 vector3 = target.transform.position - this.transform.position;
            vector3.y = 0f;
            //transform.rotation = Quaternion.Euler(0f, 112f, 0f);
            // Quaternion(回転値)を取得
            Quaternion quaternion = Quaternion.LookRotation(vector3);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, quaternion, speed);
        }
        else if (stop == true)
        {
            MaxTime -= Time.deltaTime;


        }
        if (MaxTime < 0)
        {
            count = 0;
            stop = false;
            MaxTime = 5;
        }
    }
}
