using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objecttime : MonoBehaviour
{
    public float Readytime;//�n�܂鎞��
    public Text ReadyText;//
    [SerializeField] Text EndText;//Ready���Ԃ��߂������̕���
    [SerializeField] GameObject Endcall;//Ready���Ԃ��߂������̃Q�[���I�u�W�F�N�g
    // Start is called before the first frame update
    void Start()
    {
        Endcall.SetActive(false);
        ReadyText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (1 < Readytime)
        {
            Readytime -= Time.deltaTime;
            ReadyText.text = Readytime.ToString("0");//���s���邽�߂̋󔒂����Ȃ���
        }
        else if (Readytime <= 1f)
        {
            Destroy(ReadyText);
            Endcall.SetActive(true);
            EndText.text = "�I��!!";
            Destroy(EndText, 2f);

        }
    }
}
