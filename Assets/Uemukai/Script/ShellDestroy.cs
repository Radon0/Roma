using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellDestroy : MonoBehaviour
{
    
    //void Update()
    //{
    //    if(transform.position.z >= 50.0f)
    //        //�e�������X�N���v�gF
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
