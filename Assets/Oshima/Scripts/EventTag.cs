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

	public float time=90f;//戦闘時間

	private void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.tag=="Enemy")
		{
			logSystem.AddLogText("<color=green>" + collision.gameObject.GetComponent<EnemyInfomation>().EnemyName + "</color>" + "が<color=blue>" + areaName + "</color>" + "に接触しました。", LogInfomation.LogType.Event);
		}
        if (collision.gameObject.tag == "Player")
        {
            logSystem.AddLogText("<color=green>" + collision.gameObject.GetComponent<PlayerInfomation>().PlayerName + "</color>" + "が<color=blue>" + areaName + "</color>" + "に接触しました。", LogInfomation.LogType.Event);
        }
    }
	void Update() 
	{
		time -= Time.deltaTime;
        if (time == 58f)
        {
			logSystem.AddLogText("<color=green>" + gameObject.GetComponent<PlayerInfomation>().PlayerName + "</color>" + "が<color=blue>" + areaName + "</color>" + "に接触しました。", LogInfomation.LogType.Event);

			logSystem.AddLogText("<color=green>"  + "</color>" + "が<color=blue>" + areaName + "</color>" + "に接触しました。", LogInfomation.LogType.Event);

		}

	}
}