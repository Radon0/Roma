using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellDestroy : MonoBehaviour
{

    private void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.black;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
