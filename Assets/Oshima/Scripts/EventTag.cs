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

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			logSystem.AddLogText("<color=green>" + other.GetComponent<PlayerInfomation>().PlayerName + "</color>" + "��<color=blue>" + areaName + "</color>" + "�ɐN�����܂����B", LogInfomation.LogType.Event);
		}
	}

    private void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.tag=="Enemy")
		{
			logSystem.AddLogText("<color=green>" + collision.gameObject.GetComponent<PlayerInfomation>().PlayerName + "</color>" + "��<color=blue>" + areaName + "</color>" + "�ɐڐG���܂���", LogInfomation.LogType.Event);
		}
	}
}