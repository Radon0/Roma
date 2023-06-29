using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private CharacterController enemyController;
    private Animator animator;
    //�ړI�n
    private Vector3 destination;
    [SerializeField] private float walkSpeed = 1.0f;
    //���x
    private Vector3 velocity;
    //�ړ�����
    private Vector3 direction;
    //�����t���O
    private bool arrived;
    //�X�^�[�g�ʒu
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        var randDestination = Random.insideUnitCircle * 8;
        destination = startPosition + new Vector3(randDestination.x, 0f, randDestination.y);
        velocity = Vector3.zero;
        arrived = false;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyController.isGrounded)
        {
            velocity = Vector3.zero;
            animator.SetFloat("Speed", 2.0f);
            direction = (destination - transform.position).normalized;
            transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
            velocity = direction * walkSpeed;
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        enemyController.Move(velocity * Time.deltaTime);

        //�ړI�n�ɓ����������̔���
        if(Vector3.Distance(transform.position,destination)<0.5f)
        {
            arrived = true;
            animator.SetFloat("Speed", 0.0f);
        }
    }
}
