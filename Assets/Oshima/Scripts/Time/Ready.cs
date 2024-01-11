using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ready : MonoBehaviour
{
    public static Ready Instance;
    private bool hasWon = false;
    public float Readytime = 3.0f;//�n�܂鎞��
    private Text ReadyText;//�ŏ��̃e�L�X�g
    public Text timerText;//�퓬�ł̐�������
    [SerializeField] Text WinLoseText;//����������������
    public float totalTime;
    [SerializeField] Text callText;//���Ԃ��߂������̕���
    [SerializeField] private HPController hpScript;//������������
    [SerializeField] private HPController Enemy;
    public bool winLose=false;//�����ʒu���Z�b�g�̂���
    public bool Round=false;//���������Z�b�g
    //public MoveEnemy moveEnemy;
    public int WinCount=0;//������
    public int LoseCount=0;//������
    public int RoundCount;//���E���h
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
        WinLoseText.enabled = false;
        ReadyText = GetComponent<Text>();
        callText.enabled = false;
    }
    void Update()
    {
        hasWon = false;
        if (Round == false)
        {
           
           
            if (1 < Readytime)
            {
                ReadyText.enabled = true;
                Readytime -= Time.deltaTime;
                ReadyText.text = Readytime.ToString("Round"+(RoundCount)+"\n     0");//���s���邽�߂̋󔒂����Ȃ���
            }
            else if (Readytime <= 1f)
            {
                timerText.enabled = false;
                ReadyText.text = Readytime.ToString("   GO!!");
                Invoke("Timeup", 2f);
            }
            if (!ReadyText.enabled)
            {
                if (!hasWon) // �������肪�������Ă��Ȃ��ꍇ�ɂ̂ݔ�����s��
                {
                   
                    totalTime -= Time.deltaTime;
                    timerText.enabled = true;
                    timerText.text = totalTime.ToString("00");
                    if (Enemy.isDead == true)
                    {
                        Win();
                    }
                    if(hpScript.isDead == true)
                    {
                        Lose();
                    }
                    if (Enemy.Hp == 0 && hpScript.Hp == 0)
                    {
                        Double();
                    }
                    if (totalTime <= 0f)
                    {
                        Destroy(timerText);
                        totalTime = 0;
                        callText.enabled = true;
                        timerText.enabled = false;
                        callText.text = "TIME UP";
                        //Invoke("Timer", 3f);
                        Destroy(callText, 3f);
                        Invoke("CheckWinCondition",4f);
                    }
                    
                }
                
                hasWon = false;
                
            }
    
        }
}

    private void Win()//�v���C���[����������
    {
        hasWon = true;
        WinCount += 1;
        totalTime = 0;
        WinLoseText.enabled = true;
        WinLoseText.text = "YOUWIN";
        Invoke("win", 4f);
        Invoke("Destroy", 0f);
        winLose = true;
        Round = true;
        Invoke("SceneChange", 6f);
    }
    private void Lose()
    {
        hasWon = true;
        LoseCount += 1;
        totalTime = 0;
        WinLoseText.enabled = true;
        WinLoseText.text = "YOULOSE";
        Invoke("win", 4f);
        Invoke("Destroy", 0f);
        winLose = true;
        Round = true;
    }
    private void Double()//���ł�
    {
        hasWon = true;
        WinLoseText.enabled = true;
        WinLoseText.text = "DOUBLE";
        Invoke("win",4f);
        Invoke("Destroy",0f);
        winLose = true;
         Round = true;
}
    private void CheckWinCondition()
    {

        // �v���C���[�����������Ƃ�
        if (Enemy.Hp < hpScript.Hp && !hpScript.isDead && totalTime == 0)
        {
            Win();
        }

        // �v���C���[���s�k�����Ƃ�
        if (Enemy.Hp > hpScript.Hp && !Enemy.isDead&& totalTime == 0)
        {
             Lose();
        }

        // ���ł��̏ꍇ
        if (totalTime==0&& Enemy.Hp == hpScript.Hp)
        {
            Double();
        }
    }
    public void Timer()
    {
        timerText.enabled = false;
    }
    public void Timeup()
    {
       
        ReadyText.enabled = false;
    }
    private void win()
    {
        //Destroy(WinLoseText, 4f);
        WinLoseText.enabled = false;
       
    }
    private void Destroy()
    {
        // Destroy(callText);
        //Destroy(toatl);
        callText.enabled = false;
        timerText.enabled = false;
    }
    private void SceneChange()
    {
        if (WinCount == 1)
        {
            SceneManager.LoadScene(3);
        }
        if (WinCount == 1 && LoseCount == 1)
        {
            SceneManager.LoadScene(2);
        }
        if (LoseCount == 1)
        {
            SceneManager.LoadScene(2);
        }
    }

}


