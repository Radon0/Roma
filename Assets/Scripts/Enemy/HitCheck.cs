using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="AttackEnemy")
        {
            Debug.Log("当たった！");
            //Destroy(this.gameObject);
        }
    }
}
