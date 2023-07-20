using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    //�v���C���[�̃I�u�W�F�N�g
    public GameObject playerObj;
    //�����ʒu
    private Vector3 startPosition;
    //�ړI�n
    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        //�����ʒu��ݒ�
        startPosition = transform.position;
        SetDestination(transform.position);
    }


    private void Update()
    {
        destination = playerObj.transform.position;
    }

    //�ړI�n��ݒ肷��
    public void SetDestination(Vector3 position)
    {
        destination = position;
    }

    //�ړI�n���擾����
    public Vector3 GetDestination()
    {
        return destination;
    }
}
