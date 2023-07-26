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

	public float time;//�퓬����
	private bool isLogged = false;
	private bool isa= false;
	private bool b = false;

	void Update()
	{
		if (Time.time >= 20f && !isLogged)
		{
			isLogged = true; // ���O��\���������Ƃ��L�^
			logSystem.AddLogText("<color=blue>�g��"+"</color>"+"���o��������!���ӂ���!!", LogInfomation.LogType.Event);
		}
		if (Time.time >= 34f && !isa)
		{
			isa = true; // ���O��\���������Ƃ��L�^
			logSystem.AddLogText("<color=blue>���ˊ�"+"</color>"+"���o��!�񕜂̃`�����X��!!", LogInfomation.LogType.Event);
		}
		if (Time.time >= 40f && !b)
		{
			b = true; // ���O��\���������Ƃ��L�^
			logSystem.AddLogText("<color=blue>���"+"</color>"+"���o��!!���ӂ���!!", LogInfomation.LogType.Event);
		}
	}
	private void OnCollisionEnter(Collision collision)
    {
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