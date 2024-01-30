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
            
                //エフェクトを生成する
                GameObject effect = Instantiate(ExploadObj) as GameObject;
                //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
                effect.transform.position = gameObject.transform.position;

                Destroy(gameObject,4f);
            
        }
    }
}