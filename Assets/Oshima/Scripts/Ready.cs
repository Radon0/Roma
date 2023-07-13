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
            if (hpScript.isDead == true)//死んだとき
            {
                Destroy(callText);
                Destroy(toatl);
                Lose();
            }
            else if (Enemy.isDead == true)//敵が死んだとき
            {
                Destroy(callText);
                Destroy(toatl);
                Win();
            }
            else if (Enemy.EnemyHpControll == hpScript.Hp)//同じ時
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
                if (!callText&&Enemy.EnemyHpControll < hpScript.Hp)//敵よりHpが多い時
                {
                    Win();
                }
                else if (!callText && Enemy.EnemyHpControll > hpScript.Hp)//敵よりHpが低い時
                {
                    Lose();
                }
                else if (!callText && Enemy.EnemyHpControll == hpScript.Hp)//同じ時
                {
                    Double();
                }

            }

        }
    }

    private void Win()//プレイヤーが勝った時
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
    private void Double()//相打ち
    {
        WinLose.SetActive(true);
        WinLoseText.text = "DOUBLE";
        Destroy(callText, 4f);
    }

}


