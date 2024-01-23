using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public bool stop=false;
    public GameObject ShellPrefab;

    public float MaxTime;
    [SerializeField]
    [Tooltip("�Ώە�(��������)")]
    private GameObject target;

    [SerializeField]
    [Tooltip("�Ώە��������܂ł̃X�s�[�h[0-1](�l���������قǌ����܂ł̃X�s�[�h���x��")]
    private float speed;
    
    //public AudioClip sound;
    public int count;
    void Update()
    {
        count += 1;
        if (count == 1000&&stop==false)
        //���ˊԊuF
        {
            Vector3 spawnPosition = transform.position + new Vector3(0, 3f, 0);
            GameObject Shell = Instantiate(ShellPrefab, spawnPosition, Quaternion.identity);
            Rigidbody shellRb = Shell.GetComponent<Rigidbody>();
            stop=true;
            shellRb.AddForce(transform.forward * 1300);

            //�e���ݒ�
            count=0;
            //AudioSource.PlayClipAtPoint(sound, transform.position);

            Destroy(Shell, 5.0f);
            //�e����������ɔj�󂷂�F ��肭�����Ȃ��̂�ShellDestroy���쐬
        }

        if (stop == false)
        {

            // �Ώە��Ǝ������g�̍��W����x�N�g�����Z�o����Quaternion(��]�l)���擾
            Vector3 vector3 = target.transform.position - this.transform.position;
            vector3.y = 0f;
            //transform.rotation = Quaternion.Euler(0f, 112f, 0f);
            // Quaternion(��]�l)���擾
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
