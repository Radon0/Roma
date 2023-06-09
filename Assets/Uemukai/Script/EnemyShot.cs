using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject ShellPrefab;
    public AudioClip sound;
    private int count;
    void Update()
    {
        count += 1;
        if (count % 250 == 0)
        //発射間隔F
        {
            GameObject Shell = Instantiate(ShellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = Shell.GetComponent<Rigidbody>();

            shellRb.AddForce(transform.forward * 1000);
            //弾速設定

            AudioSource.PlayClipAtPoint(sound, transform.position);

            //Destroy(Shell, 5.0f);
            //弾を撃った後に破壊するF 上手くいかないのでShellDestroyを作成
        }
    }
}
