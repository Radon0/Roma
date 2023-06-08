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

    private float totalTime;
	//　制限時間（分）
	[SerializeField]
	private int minute;
    //　制限時間（秒）
    [SerializeField]
	private float seconds;
	//　前回Update時の秒数
	private float oldSeconds;

	[SerializeField] Text callText;//時間が過ぎた時の文字
	[SerializeField] GameObject call;//時間が過ぎた時のゲームオブジェクト
	
    void Start()
    {
		Gocall.SetActive(false);
        totalTime = minute * 60 + seconds;
        oldSeconds = 0f;		
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
			//　一旦トータルの制限時間を計測；
			totalTime = minute * 60 + seconds;
			totalTime -= Time.deltaTime;

			//　再設定
			minute = (int)totalTime / 60;
			seconds = totalTime - minute * 60;

			//　タイマー表示用UIテキストに時間を表示する
			if ((int)seconds != (int)oldSeconds)
			{
				timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
			}
			oldSeconds = seconds;
			//　制限時間以下になったらコンソールに『制限時間終了』という文字列を表示する
			if (totalTime <= 0f)
			{
				call.SetActive(true);
				timerText.enabled = false;
				callText.text = "TIME UP";

			}
		}
	}
}

