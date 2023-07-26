using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTag : MonoBehaviour
{//　ログシステム
	[SerializeField]
	private LogInfomation logSystem;
	//　エリアの名前
	[SerializeField]
	private string areaName;

	public float time;//戦闘時間
	private bool isLogged = false;
	private bool isa= false;
	private bool b = false;

	void Update()
	{
		if (Time.time >= 20f && !isLogged)
		{
			isLogged = true; // ログを表示したことを記録
			logSystem.AddLogText("<color=blue>トラ"+"</color>"+"が出現したぞ!注意しろ!!", LogInfomation.LogType.Event);
		}
		if (Time.time >= 34f && !isa)
		{
			isa = true; // ログを表示したことを記録
			logSystem.AddLogText("<color=blue>注射器"+"</color>"+"が出現!回復のチャンスだ!!", LogInfomation.LogType.Event);
		}
		if (Time.time >= 40f && !b)
		{
			b = true; // ログを表示したことを記録
			logSystem.AddLogText("<color=blue>戦車"+"</color>"+"が出現!!注意しろ!!", LogInfomation.LogType.Event);
		}
	}
	private void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.tag=="Enemy")
		{		
			logSystem.AddLogText("<color=green>"+collision.gameObject.GetComponent<EnemyInfomation>().EnemyName+"</color>"+"が<color=blue>" + areaName + "</color>" + "に接触しました。", LogInfomation.LogType.Event);
		}
        if (collision.gameObject.tag == "Player")
        {
            logSystem.AddLogText("<color=green>"+collision.gameObject.GetComponent<PlayerInfomation>().PlayerName + "</color>" + "が<color=blue>" + areaName + "</color>" + "に接触しました。", LogInfomation.LogType.Event);
        }
    }

}