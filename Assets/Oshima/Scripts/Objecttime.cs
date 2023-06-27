using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objecttime : MonoBehaviour
{
    public float Readytime;//始まる時間
    public Text ReadyText;//
    [SerializeField] Text EndText;//Ready時間が過ぎた時の文字
    [SerializeField] GameObject Endcall;//Ready時間が過ぎた時のゲームオブジェクト
    // Start is called before the first frame update
    void Start()
    {
        Endcall.SetActive(false);
        ReadyText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (1 < Readytime)
        {
            Readytime -= Time.deltaTime;
            ReadyText.text = Readytime.ToString("0");//改行するための空白けさないで
        }
        else if (Readytime <= 1f)
        {
            Destroy(ReadyText);
            Endcall.SetActive(true);
            EndText.text = "終了!!";
            Destroy(EndText, 2f);

        }
    }
}
