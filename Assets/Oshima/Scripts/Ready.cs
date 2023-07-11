using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ready : MonoBehaviour
{
    public float Readytime = 3.0f;//始まる時間
    private Text ReadyText;//
    public Text timerText;//戦闘での制限時間
    [SerializeField] Text GoText;//Ready時間が過ぎた時の文字
    [SerializeField] GameObject Gocall;//Ready時間が過ぎた時のゲームオブジェクト
    public float totalTime;
    ////　制限時間（分）
    //[SerializeField]
    //private int minute;
    //　制限時間（秒）
    //   [SerializeField]
    //private float seconds;
    ////　前回Update時の秒数
    //private float oldSeconds;

    [SerializeField] Text callText;//時間が過ぎた時の文字
    [SerializeField] GameObject call;//時間が過ぎた時のゲームオブジェクト
    [SerializeField] GameObject toatl;
    public HPController hpScript;//勝ち負け判定
    public EnemyController Enemy;
    void Start()
    {
        Gocall.SetActive(false);
        toatl.SetActive(false);
        //totalTime = /*minute*/ * 60 + seconds;
        /*oldSeconds = 0f*/
        ;
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
            ReadyText.enabled = false;
            Gocall.SetActive(true);
            GoText.text = "GO!!";
            Destroy(GoText, 2f);

        }
        if (!GoText)
        {
            toatl.SetActive(true);
            totalTime -= Time.deltaTime;
            timerText.text = totalTime.ToString("00");

            if (hpScript.isDead == true)//死んだとき
            {
                call.SetActive(true);
                timerText.enabled = false;
                callText.text = "YOULOSE";
                Destroy(this, 3f);
            }
            else if (Enemy.isDead == true)
            {
                call.SetActive(true);
                timerText.enabled = false;
                callText.text = "YOUWIN";
                Destroy(this, 3f);
            }
            else if (totalTime <= 0f)
            {
                call.SetActive(true);
                timerText.enabled = false;
                callText.text = "TIME UP";
                Destroy(this, 3f);

            }

            //　一旦トータルの制限時間を計測；
            //totalTime = minute * 60 + seconds;
            //totalTime -= Time.deltaTime;

            ////　再設定
            //minute = (int)totalTime / 60;
            //seconds = totalTime - minute * 60;

            //　タイマー表示用UIテキストに時間を表示する
            //	if ((int)seconds != (int)oldSeconds)
            //	{
            //		timerText.text =((int)seconds).ToString("00");
            //	}
            //	oldSeconds = seconds;
            //	//　制限時間以下になったらコンソールに『制限時間終了』という文字列を表示する
            //	if (totalTime <= 0f)
            //	{
            //		call.SetActive(true);
            //		timerText.enabled = false;
            //		callText.text = "TIME UP";

            //	}

        }
    }
}


