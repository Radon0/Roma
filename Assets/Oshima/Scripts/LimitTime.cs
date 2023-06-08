using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitTime : MonoBehaviour
{
    //�@�g�[�^����������
    private float totalTime;
	//�@�������ԁi���j
	[SerializeField]
	private int minute;
    //�@�������ԁi�b�j
    [SerializeField]
	private float seconds;
	//�@�O��Update���̕b��
	private float oldSeconds;
	private Text timerText;
	[SerializeField] Text callText;//���Ԃ��߂������̕���
	[SerializeField] GameObject call;//���Ԃ��߂������̃Q�[���I�u�W�F�N�g
	
	
	void Start()
	{		
		call.SetActive(false);
		totalTime = minute * 60 + seconds;
		oldSeconds = 0f;
		timerText = GetComponentInChildren<Text>();
	}

	void Update()
	{
		//�@�������Ԃ�0�b�ȉ��Ȃ牽�����Ȃ�
		if (totalTime <= 0f)
		{
			return;
		}
		//�@��U�g�[�^���̐������Ԃ��v���G
		totalTime = minute * 60 + seconds;
		totalTime -= Time.deltaTime;

		//�@�Đݒ�
		minute = (int)totalTime / 60;
		seconds = totalTime - minute * 60;

		//�@�^�C�}�[�\���pUI�e�L�X�g�Ɏ��Ԃ�\������
		if ((int)seconds != (int)oldSeconds)
		{
			timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
		}
		oldSeconds = seconds;
		//�@�������Ԉȉ��ɂȂ�����R���\�[���Ɂw�������ԏI���x�Ƃ����������\������
		if (totalTime <= 0f)
		{
			call.SetActive(true);		
			timerText.enabled = false;
			callText.text = "TIME UP";
		
		}
	}
}
