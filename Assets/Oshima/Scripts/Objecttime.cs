using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objecttime : MonoBehaviour
{
    public float Readytime;//�n�܂鎞��
    private Text ReadyText;//
    public Text timerText;//�퓬�ł̐�������
    [SerializeField] Text GoText;//Ready���Ԃ��߂������̕���
    [SerializeField] GameObject Gocall;//Ready���Ԃ��߂������̃Q�[���I�u�W�F�N�g
    // Start is called before the first frame update
    void Start()
    {
        Gocall.SetActive(false);
        ReadyText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (1 < Readytime)
        {
            Readytime -= Time.deltaTime;
            ReadyText.text = Readytime.ToString("�c��z�u����\n     0");//���s���邽�߂̋󔒂����Ȃ���
        }
        else if (Readytime <= 1f)
        {
            Destroy(ReadyText);
            Gocall.SetActive(true);
            GoText.text = "GO!!";
            Destroy(GoText, 2f);

        }
    }
}
