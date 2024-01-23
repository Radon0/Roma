using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private CapsuleCollider capsule;
    public GameObject ExploadObj;
    // Start is called before the first frame update
    void Start()
    {
        capsule=GetComponent<CapsuleCollider>();
        Invoke("Explode", 5f);
        Destroy(gameObject, 5.5f);
    }
    private void Update()
    {
    
    }
    private void Explode()
    {
        Instantiate(ExploadObj, transform.position, Quaternion.identity);
        capsule.enabled = true;
    }
}
