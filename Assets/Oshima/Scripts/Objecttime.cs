using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objecttime : MonoBehaviour
{
    public float Readytime;//始まる時間
    private Text ReadyText;//
    public Text timerText;//戦闘での制限時間
    [SerializeField] Text GoText;//Ready時間が過ぎた時の文字
    [SerializeField] GameObject Gocall;//Ready時間が過ぎた時のゲームオブジェクト
    // Start is called before the first frame update
    void Start()
    {
        Gocall.SetActive(false);
        ReadyText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (1 < Readytime)
        {
            Readytime -= Time.deltaTime;
            ReadyText.text = Readytime.ToString("残り配置時間\n     0");//改行するための空白けさないで
        }
        else if (Readytime <= 1f)
        {
            Destroy(ReadyText);
            Gocall.SetActive(true);
            GoText.text = "GO!!";
            Destroy(GoText, 2f);

        }
    }
}
