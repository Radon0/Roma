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

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Syringes")
		{
			logSystem.AddLogText("<color=blue>注射器"+"</color>"+"が出現!回復のチャンスだ!!", LogInfomation.LogType.Event);
		}
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