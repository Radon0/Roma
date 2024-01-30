using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject ExploadObj;
    // Start is called before the first frame update
    void Start()
    {



    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")||other.gameObject.CompareTag("Enemy"))
        {
            
                //�G�t�F�N�g�𐶐�����
                GameObject effect = Instantiate(ExploadObj) as GameObject;
                //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
                effect.transform.position = gameObject.transform.position;

                Destroy(gameObject,4f);
            
        }
    }
}