using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LogInfomation : MonoBehaviour
{//�@�\�����郍�O�̎�ނ̗񋓌^
	public enum LogType
	{
		All,
		Time,
		Event
	}

	//�@���O�o�͐�e�L�X�g
	[SerializeField]
	private Text logText;
	//�@�S�f�[�^
	private List<string> allLogs;
	//�@���Ԃ̃f�[�^
	private List<string> timerLogs;
	//�@�C�x���g�̃f�[�^
	private List<string> eventLogs;
	//�@���ݕ\�����郍�O�̎��
	[SerializeField]
	private LogType logTypeToDisplay = LogType.All;
	//�@���O��ۑ����鐔
	[SerializeField]
	private int allLogDataNum = 10;
	[SerializeField]
	private int timerLogDataNum = 10;
	[SerializeField]
	private int eventLogDataNum = 10;

    internal void AddLogText(object p, LogType @event)
    {
        throw new NotImplementedException();
    }

    //�@�c�̃X�N���[���o�[
    [SerializeField]
	private Scrollbar verticalScrollbar;
	private StringBuilder logTextStringBuilder;

	// Start is called before the first frame update
	void Start()
	{
		allLogs = new List<string>();
		timerLogs = new List<string>();
		eventLogs = new List<string>();
		logTextStringBuilder = new StringBuilder();
	}
	//�@���O�e�L�X�g�̒ǉ�
	public void AddLogText(string logText, LogType logType)
	{
		//�@���O�e�L�X�g�̒ǉ�
		allLogs.Add(logText);
		if (logType == LogType.Event)
		{
			eventLogs.Add(logText);
		}
		else if (logType == LogType.Time)
		{
			timerLogs.Add(logText);
		}
		//�@���O�̍ő�ۑ����𒴂�����Â����O���폜
		if (allLogs.Count > allLogDataNum)
		{
			allLogs.RemoveRange(0, allLogs.Count - allLogDataNum);
		}
		if (timerLogs.Count > timerLogDataNum)
		{
			timerLogs.RemoveRange(0, timerLogs.Count - timerLogDataNum);
		}
		if (eventLogs.Count > eventLogDataNum)
		{
			eventLogs.RemoveRange(0, eventLogs.Count - eventLogDataNum);
		}
		//�@���O�e�L�X�g�̕\��
		if (logTypeToDisplay == LogType.All || logTypeToDisplay == logType)
		{
			ViewLogText();
		}
	}

	//�@�ォ�烍�O��ǉ�����o�[�W����
	//�@���O�e�L�X�g�̕\��
	public void ViewLogText()
	{
		logTextStringBuilder.Clear();
		List<string> selectedLogs = new List<string>();
		//�@���O�^�C�v�ɂ���ĕ\�����郍�O��ς���
		if (logTypeToDisplay == LogType.All)
		{
			selectedLogs = allLogs;
		}
		else if (logTypeToDisplay == LogType.Event)
		{
			selectedLogs = eventLogs;
		}
		else if (logTypeToDisplay == LogType.Time)
		{
			selectedLogs = timerLogs;
		}

		foreach (var log in selectedLogs)
		{
			logTextStringBuilder.Insert(0, log + Environment.NewLine);
		}
		logText.text = logTextStringBuilder.ToString().TrimEnd();
		UpdateScrollBar();
	}
	// �X�N���[���o�[�̈ʒu�̍X�V
	public void UpdateScrollBar()
	{
		verticalScrollbar.value = 1f;
	}

}
