using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetBool("Jab", true);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            animator.SetBool("Hikick", true);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            animator.SetBool("Spinkick", true);
        }
    }
}
