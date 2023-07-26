using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ready : MonoBehaviour
{
    private bool hasWon = false;
    public float Readytime = 3.0f;//�n�܂鎞��
    private Text ReadyText;//�ŏ��̃e�L�X�g
    public Text timerText;//�퓬�ł̐�������
    [SerializeField] Text WinLoseText;//����������������
    [SerializeField] GameObject WinLose;//�����������������Q�[���I�u�W�F�N�g
    public float totalTime;
    [SerializeField] Text callText;//���Ԃ��߂������̕���
    [SerializeField] GameObject call;//���Ԃ��߂������̃Q�[���I�u�W�F�N�g
    [SerializeField] GameObject toatl;
    [SerializeField] private HPController hpScript;//������������
    [SerializeField] private HPController Enemy;
    //public MoveEnemy moveEnemy;
    public int WinCount=0;
    public int LoseCount=0;
    void Start()
    { 
        ReadyText = GetComponent<Text>();
    }
    void Update()
    {
        if (1 < Readytime)
        {
            Readytime -= Time.deltaTime;
            ReadyText.text = Readytime.ToString("READY\n     0");//���s���邽�߂̋󔒂����Ȃ���
        }
        else if (Readytime <= 1f)
        {
            ReadyText.text = Readytime.ToString("   GO!!");
            Destroy(ReadyText, 2f);
        }
        if (!ReadyText)
        {
            if (!hasWon) // �������肪�������Ă��Ȃ��ꍇ�ɂ̂ݔ�����s��
            {
                toatl.SetActive(true);
                totalTime -= Time.deltaTime;
                timerText.text = totalTime.ToString("00");
                //Win();
                //Lose();
                //Double();
                if (totalTime <= 0f)
                {
                    totalTime = 0;
                    call.SetActive(true);
                    timerText.enabled = false;
                    callText.text = "TIME UP";
                    Destroy(callText, 3f);
                    //Win();
                    //Lose();
                    //Double();

                }

            }
        CheckWinCondition();
        hasWon = false;
    }
}

    private void Win()//�v���C���[����������
    {
        hasWon = true;
        WinCount = +1;
        totalTime = 0;
        WinLose.SetActive(true);
        WinLoseText.text = "YOUWIN";
        Destroy(WinLoseText, 4f);
        Destroy(callText);
        Destroy(toatl);
        //if (Enemy.isDead == true)//�G�����񂾂Ƃ�
        //{
        //    WinCount = +1;
        //    totalTime = 0;
        //    WinLose.SetActive(true);
        //    WinLoseText.text = "YOUWIN";
        //    Destroy(WinLoseText, 4f);
        //    Destroy(callText);
        //    Destroy(toatl);
        //}

        //if (!callText && Enemy.Hp < hpScript.Hp)//�G���Hp��������
        //{
        //    WinCount = +1;
        //    WinLose.SetActive(true);
        //    WinLoseText.text = "YOUWIN";
        //    Destroy(WinLoseText, 4f);

        //}
    }
    private void Lose()
    {
        hasWon = true;
        LoseCount = +1;
        totalTime = 0;
        WinLose.SetActive(true);
        WinLoseText.text = "YOULOSE";
        Destroy(WinLoseText, 4f);
        Destroy(callText);
        Destroy(toatl);

        //if (hpScript.isDead == true)//���񂾂Ƃ�
        //{
        //    LoseCount = +1;
        //    totalTime = 0;
        //    WinLose.SetActive(true);
        //    WinLoseText.text = "YOULOSE";
        //    Destroy(WinLoseText, 4f);
        //    Destroy(callText);
        //    Destroy(toatl);
        //}
        //if (!callText && Enemy.Hp > hpScript.Hp)
        //{
        //    LoseCount = +1;
        //    WinLose.SetActive(true);
        //    WinLoseText.text = "YOULOSE";
        //    Destroy(WinLoseText, 4f);
        //}//�G���Hp��������
    }
    private void Double()//���ł�
    {
        hasWon = true;
        WinLose.SetActive(true);
        WinLoseText.text = "DOUBLE";
        Destroy(callText, 4f);
        Destroy(callText);
        Destroy(toatl);
        //if (Enemy.Hp == 0 && hpScript.Hp == 0)//������
        //{
        //    WinLose.SetActive(true);
        //    WinLoseText.text = "DOUBLE";
        //    Destroy(callText, 4f);
        //    Destroy(callText);
        //    Destroy(toatl);
        //}

        //if (!callText && Enemy.Hp == hpScript.Hp)//������
        //{
        //    WinLose.SetActive(true);
        //    WinLoseText.text = "DOUBLE";
        //    Destroy(callText, 4f);
        //}
    }
    private void CheckWinCondition()
    {

        // �v���C���[�����������Ƃ�
        if (Enemy.isDead == true || (Enemy.Hp < hpScript.Hp && !hpScript.isDead && !callText))
        {
            Win();
        }

        // �v���C���[���s�k�����Ƃ�
        if (hpScript.isDead == true || (Enemy.Hp > hpScript.Hp && !Enemy.isDead&&!callText))
        {
             Lose();
        }

        // ���ł��̏ꍇ
        if (Enemy.Hp == 0 && hpScript.Hp == 0 || (!callText && Enemy.Hp == hpScript.Hp))
        {
            Double();
        }
    }



}


