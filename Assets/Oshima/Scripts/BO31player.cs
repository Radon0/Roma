using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BO31player : MonoBehaviour
{

    public Image[] childVictoryMarks; // �q�I�u�W�F�N�g�̏����}�[�N��Image�R���|�[�l���g�̔z��

    public Ready player1Wins; // �v���C���[1�̏�����
    private int winsCount = 0;
    private void Start()
    {
        ResetVictoryDisplay();
        winsCount = player1Wins.WinCount;
    }

    // �����}�[�N�����Z�b�g���郁�\�b�h
    private void ResetVictoryDisplay()
    {
        winsCount = 0;


        // ���ׂĂ̎q�I�u�W�F�N�g�̏����}�[�N���\���ɂ���
        foreach (var mark in childVictoryMarks)
        {
            mark.enabled = false;
        }
    }

    // �����񐔂𑝂₵�Ďq�I�u�W�F�N�g�̏����}�[�N��\�����郁�\�b�h
    public void Update()
    {
        if (winsCount < childVictoryMarks.Length)
        {
            childVictoryMarks[winsCount].enabled = true;
            winsCount++;
        }
    }
}
