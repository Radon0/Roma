using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BO3Maneger : MonoBehaviour
{
    //public int winsNeeded = 2; // BO3�`���Ȃ̂�2���K�v
    public GameObject[] WinMark; // �v���C���[1�̏����}�[�N
    //public GameObject player2WinMark; // �v���C���[2�̏����}�[�N
    //private int winsCount = 0;
    //public Image[] parentVictoryMarks; // �e�I�u�W�F�N�g�̏����}�[�N��Image�R���|�[�l���g�̔z��
    public Ready player1Wins; // �v���C���[1�̏�����
    private void Start()
    {
        //ResetVictoryDisplay();

    }
    // �����}�[�N�����Z�b�g���郁�\�b�h
    //private void ResetVictoryDisplay()
    //{
    //    player1Wins.WinCount = 0;

    //    // ���ׂĂ̐e�I�u�W�F�N�g�̏����}�[�N���\���ɂ���
    //    foreach (var mark in parentVictoryMarks)
    //    {
    //        mark.enabled = false;
    //    }
    //}
    //public void AddWin()
    //{
    //    if (player1Wins.WinCount < 0)
    //    {
    //        parentVictoryMarks[player1Wins.WinCount].enabled = true;
         
    //    }

    //}
    public void Update()
    {


        switch (player1Wins.WinCount)//��������
        {
            case 1:
                {
                    WinMark[0].SetActive(true);
                    break;
                }
            case 2:
                {
                    WinMark[1].SetActive(true);
                    break;
                }
        }
        switch (player1Wins.LoseCount)//��������
        {
            case 1:
                {
                    WinMark[2].SetActive(true);
                    break;

                }
            case 2:
                {
                    WinMark[3].SetActive(true);
                    break;
                }
        }
    }
}
