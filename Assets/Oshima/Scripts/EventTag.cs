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

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Syringes")
		{
			logSystem.AddLogText("<color=blue>���ˊ�"+"</color>"+"���o��!�񕜂̃`�����X��!!", LogInfomation.LogType.Event);
		}
		if (collision.gameObject.tag=="Enemy")
		{		
			logSystem.AddLogText("<color=green>"+collision.gameObject.GetComponent<EnemyInfomation>().EnemyName+"</color>"+"��<color=blue>" + areaName + "</color>" + "�ɐڐG���܂����B", LogInfomation.LogType.Event);
		}
        if (collision.gameObject.tag == "Player")
        {
            logSystem.AddLogText("<color=green>"+collision.gameObject.GetComponent<PlayerInfomation>().PlayerName + "</color>" + "��<color=blue>" + areaName + "</color>" + "�ɐڐG���܂����B", LogInfomation.LogType.Event);
        }
    }

}