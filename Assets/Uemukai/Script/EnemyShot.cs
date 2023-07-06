using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject shellprefab;
    public AudioClip sound;
    private int count;
    void Update()
    {
        count += 1;
        if (count % 60 == 0)
        {
            GameObject shell = Instantiate(shellprefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            shellRb.AddForce(transform.forward * 500);

            AudioSource.PlayClipAtPoint(sound, transform.position);

            Destroy(shell, 5.0f);
        }
    }
}
