using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ready : MonoBehaviour
{
    public static Ready Instance;
    public float Readytime = 3.0f;//始まる時間
    private Text ReadyText;//最初のテキスト
    public Text timerText;//戦闘での制限時間
    [SerializeField] Text WinLoseText;//勝った時負けた時
    public float totalTime;
    [SerializeField] Text callText;//時間が過ぎた時の文字
    [SerializeField] private HPController hpScript;//勝ち負け判定
    [SerializeField] private HPController Enemy;
    public bool winLose=false;//初期位置リセットのため
    public bool Round=false;//処理をリセット
    //public MoveEnemy moveEnemy;
    public int WinCount=0;//勝ち数
    public int LoseCount=0;//負け数
    public int RoundCount;//ラウンド
    private bool isGameOver = false;
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
       
        if (Round == false)
        {
           
           
            if (1 < Readytime)
            {
                ReadyText.enabled = true;
                Readytime -= Time.deltaTime;
                ReadyText.text = Readytime.ToString("Round"+(RoundCount)+"\n     0");//改行するための空白けさないで
            }
            else if (Readytime <= 1f)
            {
                //timerText.enabled = false;
                ReadyText.text = Readytime.ToString("   GO!!");
                Invoke("Timeup", 2f);
            }
            if (!ReadyText.enabled)
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
                    if (!isGameOver&&totalTime <= 0)
                       {
                        isGameOver = true;
                      //Destroy(timerText);
                        totalTime = 0;
                        callText.enabled = true;
                        timerText.enabled = false;
                        callText.text = "TIME UP";
                        //Invoke("Timer", 3f);
                        Destroy(callText, 3f);
                        Invoke("CheckWinCondition", 4f);
                    }
                    else if (totalTime < 0)
                {
                    totalTime = 0;
                    timerText.enabled = false;

                }
                         

            }
    
        }

    }

    private void Win()//プレイヤーが勝った時
    {
        isGameOver = false;
        WinCount += 1;
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
        isGameOver = false;
        LoseCount += 1;
        WinLoseText.enabled = true;
        WinLoseText.text = "YOULOSE";
        Invoke("win", 4f);
        Invoke("Destroy", 0f);
        winLose = true;
        Round = true;
        Invoke("SceneChange", 6f);
    }
    private void Double()//相打ち
    {
        isGameOver = false;
        WinCount += 1;
        LoseCount += 1;
        WinLoseText.enabled = true;
        WinLoseText.text = "DOUBLE";
        Invoke("win",4f);
        Invoke("Destroy",0f);
        winLose = true;
         Round = true;
        Invoke("SceneChange", 6f);
    }
    private void CheckWinCondition()
    {

        // プレイヤーが勝利したとき
        if (Enemy.Hp < hpScript.Hp)
        {
            Win();
        }

        // プレイヤーが敗北したとき
        if (Enemy.Hp > hpScript.Hp )
        {
             Lose();
        }

        // 相打ちの場合
        if ( Enemy.Hp == hpScript.Hp)
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
        if (LoseCount == 1)
        {
            SceneManager.LoadScene(5);
        }
        if (WinCount == 1 && LoseCount == 1)
        {
            SceneManager.LoadScene(4);
        }
    }

}


