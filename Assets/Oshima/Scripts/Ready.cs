using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ready : MonoBehaviour
{
    public float Readytime = 3.0f;//�n�܂鎞��
    private Text ReadyText;//
	public Text timerText;//�퓬�ł̐�������
	[SerializeField] Text GoText;//Ready���Ԃ��߂������̕���
    [SerializeField] GameObject Gocall;//Ready���Ԃ��߂������̃Q�[���I�u�W�F�N�g

    private float totalTime;
	//�@�������ԁi���j
	[SerializeField]
	private int minute;
    //�@�������ԁi�b�j
    [SerializeField]
	private float seconds;
	//�@�O��Update���̕b��
	private float oldSeconds;

	[SerializeField] Text callText;//���Ԃ��߂������̕���
	[SerializeField] GameObject call;//���Ԃ��߂������̃Q�[���I�u�W�F�N�g
	
    void Start()
    {
		Gocall.SetActive(false);
        totalTime = minute * 60 + seconds;
        oldSeconds = 0f;		
		ReadyText = GetComponent<Text>();		
	}
    void Update()
    {
        if (1 < Readytime)
        {
            Readytime -= Time.deltaTime;
            ReadyText.text = Readytime.ToString("READY\n     0");//���s���邽�߂̋󔒂����Ȃ���
        }
        else if (Readytime <= 1f)
        {
         ReadyText.enabled = false;
         Gocall.SetActive(true);
         GoText.text = "GO!!";
		 Destroy(GoText, 2f);
	
        }
        if (!GoText)
		{
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
}

