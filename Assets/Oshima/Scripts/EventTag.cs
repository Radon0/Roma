using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTag : MonoBehaviour
{//�@���O�V�X�e��
	[SerializeField]
	private LogInfomation logSystem;
	//�@�G���A�̖��O
	[SerializeField]
	private string areaName;

	public float time=90f;//�퓬����

	private void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.tag=="Enemy")
		{
			logSystem.AddLogText("<color=green>" + collision.gameObject.GetComponent<EnemyInfomation>().EnemyName + "</color>" + "��<color=blue>" + areaName + "</color>" + "�ɐڐG���܂����B", LogInfomation.LogType.Event);
		}
        if (collision.gameObject.tag == "Player")
        {
            logSystem.AddLogText("<color=green>" + collision.gameObject.GetComponent<PlayerInfomation>().PlayerName + "</color>" + "��<color=blue>" + areaName + "</color>" + "�ɐڐG���܂����B", LogInfomation.LogType.Event);
        }
    }
	void Update() 
	{
		time -= Time.deltaTime;
        if (time == 58f)
        {
			logSystem.AddLogText("<color=green>" + gameObject.GetComponent<PlayerInfomation>().PlayerName + "</color>" + "��<color=blue>" + areaName + "</color>" + "�ɐڐG���܂����B", LogInfomation.LogType.Event);

			logSystem.AddLogText("<color=green>"  + "</color>" + "��<color=blue>" + areaName + "</color>" + "�ɐڐG���܂����B", LogInfomation.LogType.Event);

		}

	}
}