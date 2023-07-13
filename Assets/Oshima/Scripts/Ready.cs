using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ready : MonoBehaviour
{
    public float Readytime = 3.0f;//�n�܂鎞��
    private Text ReadyText;//�ŏ��̃e�L�X�g
    public Text timerText;//�퓬�ł̐�������
    [SerializeField] Text WinLoseText;//����������������
    [SerializeField] GameObject WinLose;//�����������������Q�[���I�u�W�F�N�g
    public float totalTime;
    [SerializeField] Text callText;//���Ԃ��߂������̕���
    [SerializeField] GameObject call;//���Ԃ��߂������̃Q�[���I�u�W�F�N�g
    [SerializeField] GameObject toatl;
     public HPController hpScript;//������������
     public EnemyController Enemy;
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
            toatl.SetActive(true);
            totalTime -= Time.deltaTime;
            timerText.text = totalTime.ToString("00");
            if (hpScript.isDead == true)//���񂾂Ƃ�
            {
                Destroy(callText);
                Destroy(toatl);
                Lose();
            }
            else if (Enemy.isDead == true)//�G�����񂾂Ƃ�
            {
                Destroy(callText);
                Destroy(toatl);
                Win();
            }
            else if (Enemy.EnemyHpControll == hpScript.Hp)//������
            {
                Destroy(callText);
                Destroy(toatl);
                Double();
            }

            if (totalTime <= 0f)
            {
                totalTime = 0;
                call.SetActive(true);
                timerText.enabled = false;
                callText.text = "TIME UP";
                Destroy(callText, 3f);
                if (!callText&&Enemy.EnemyHpControll < hpScript.Hp)//�G���Hp��������
                {
                    Win();
                }
                else if (!callText && Enemy.EnemyHpControll > hpScript.Hp)//�G���Hp���Ⴂ��
                {
                    Lose();
                }
                else if (!callText && Enemy.EnemyHpControll == hpScript.Hp)//������
                {
                    Double();
                }

            }

        }
    }

    private void Win()//�v���C���[����������
    {
        WinLose.SetActive(true);
        WinLoseText.text = "YOUWIN";
        Destroy(WinLoseText, 4f);
    }
    private void Lose()
    {
        WinLose.SetActive(true);
        WinLoseText.text = "YOULOSE";
        Destroy(callText, 4f);
    }
    private void Double()//���ł�
    {
        WinLose.SetActive(true);
        WinLoseText.text = "DOUBLE";
        Destroy(callText, 4f);
    }

}


