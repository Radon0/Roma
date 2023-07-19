using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpHealing : MonoBehaviour
{
    HPController HpController;
    private bool healable;

    // Start is called before the first frame update
    void Start()
    {
        healable = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if(healable==true)
        {
            Healing();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            healable = true;
            Destroy(this);
        }
        if(other.gameObject.tag=="Enemy")
        {
            healable = true;
            Destroy(this);
        }
    }

    private void Healing()
    {
        HpController.Hp += 10;
    }
}
