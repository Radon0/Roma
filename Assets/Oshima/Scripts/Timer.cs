using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float startTime;
    bool isTimerStarted = false;

    public void OnClick()
    {
        // �J�n����
        startTime = Time.time;

        // �^�C�}�[���J�n�������ǂ���
        isTimerStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        // �^�C�}�[���J�n���Ă��Ȃ��ꍇ�͏��������Ȃ�
        if (!isTimerStarted)
        {
            return;
        }

        // �o�ߎ��Ԃ��v�Z�i���ݎ��� - �J�n���ԁj
        float passedTime = startTime-Time.time;

        if (passedTime < 0f)
        {
            isTimerStarted = false;
        }

    }
}
