using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacter : MonoBehaviour
{
    private EnemyController moveEnemy;

    private void Start()
    {
        moveEnemy = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerStay(Collider col)
    {
        //プレイヤーキャラクターを発見
        if(col.tag=="Player")
        {
            //敵キャラクターの状態
            
        }
    }
}
