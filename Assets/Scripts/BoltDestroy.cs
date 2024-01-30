using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltDestroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
