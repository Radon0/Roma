using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject ShellPrefab;
    //public AudioClip sound;
    private int count;
    void Update()
    {
        count += 1;
        if (count % 1000 == 0)
        //���ˊԊuF
        {
            GameObject Shell = Instantiate(ShellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = Shell.GetComponent<Rigidbody>();

            shellRb.AddForce(transform.forward * 1000);
            //�e���ݒ�

            //AudioSource.PlayClipAtPoint(sound, transform.position);

            //Destroy(Shell, 5.0f);
            //�e����������ɔj�󂷂�F ��肭�����Ȃ��̂�ShellDestroy���쐬
        }
    }
}
