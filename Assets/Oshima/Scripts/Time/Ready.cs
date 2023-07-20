using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ready : MonoBehaviour
{
    public float Readytime = 3.0f;//始まる時間
    private Text ReadyText;//最初のテキスト
    public Text timerText;//戦闘での制限時間
    [SerializeField] Text WinLoseText;//勝った時負けた時
    [SerializeField] GameObject WinLose;//勝った時負けた時ゲームオブジェクト
    public float totalTime;
    [SerializeField] Text callText;//時間が過ぎた時の文字
    [SerializeField] GameObject call;//時間が過ぎた時のゲームオブジェクト
    [SerializeField] GameObject toatl;
    public HPController hpScript;//勝ち負け判定
    public EnemyController Enemy;
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
            ReadyText.text = Readytime.ToString("READY\n     0");//改行するための空白けさないで
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
            Win();
            Lose();
            Double();
            if (totalTime <= 0f)
            {
                totalTime = 0;
                call.SetActive(true);
                timerText.enabled = false;
                callText.text = "TIME UP";
                Destroy(callText, 3f);
                Win();
                Lose();
                Double();
               
            }

        }
    }

    private void Win()//プレイヤーが勝った時
    {
    
        
        if (Enemy.isDead == true)//敵が死んだとき
        {
            WinCount=+1;
            totalTime = 0;
            WinLose.SetActive(true);
            WinLoseText.text = "YOUWIN";
            Destroy(WinLoseText, 4f);
            Destroy(callText);
            Destroy(toatl);
        }

        if (!callText && Enemy.EnemyHpControll < hpScript.Hp)//敵よりHpが多い時
        {
            WinCount=+1;
            WinLose.SetActive(true);
            WinLoseText.text = "YOUWIN";
            Destroy(WinLoseText, 4f);

        }
    }
    private void Lose()
    {
        
        if (hpScript.isDead == true)//死んだとき
        {
            LoseCount =+1 ;
            totalTime = 0;
            WinLose.SetActive(true);
            WinLoseText.text = "YOULOSE";
            Destroy(WinLoseText, 4f);
            Destroy(callText);
            Destroy(toatl);
        }
        if (!callText && Enemy.EnemyHpControll > hpScript.Hp)
        {
            LoseCount =+1 ;
            WinLose.SetActive(true);
            WinLoseText.text = "YOULOSE";
            Destroy(WinLoseText, 4f);
        }//敵よりHpが多い時
    }
    private void Double()//相打ち
    {
        if (Enemy.EnemyHpControll == hpScript.Hp)//同じ時
        {
            WinLose.SetActive(true);
            WinLoseText.text = "DOUBLE";
            Destroy(callText, 4f);
            Destroy(callText);
            Destroy(toatl);
        }

        if (!callText && Enemy.EnemyHpControll == hpScript.Hp)//同じ時
        {
            WinLose.SetActive(true);
            WinLoseText.text = "DOUBLE";
            Destroy(callText, 4f);
        }
    }

}


