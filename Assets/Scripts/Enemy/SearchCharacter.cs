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
        //�v���C���[�L�����N�^�[�𔭌�
        if(col.tag=="Player")
        {
            //�G�L�����N�^�[�̏��
            
        }
    }
}
