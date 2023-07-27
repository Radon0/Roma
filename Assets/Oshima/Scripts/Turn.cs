using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        // �Q�[���I�u�W�F�N�g�̏����ʒu�Ɖ�]���L�^
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        // LateUpdate()���\�b�h���g�����ƂŁA���̃X�N���v�g�ɂ��ύX�������Ă����̃X�N���v�g���Ō�ɏ��������
        // ����ɂ��A�ʒu�Ɖ�]���ύX����Ȃ��悤�ɂȂ�
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
