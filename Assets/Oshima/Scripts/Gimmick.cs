using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gimmick : MonoBehaviour
{
    [SerializeField] Slider iineSlider;
    //public GameObject gimmick;
    private Vector3 defaultPos;
    private Vector3 defaultLocate;
    private Vector3 defaultScale;
    public List<GameObject> myList = new List<GameObject>();//�ꉞ�����̃M�~�b�N������悤�ɂ͂��Ă���        
    private int GimimckCount;//�M�~�b�N�̕\����
    public float startTime;
    public bool isTimerStarted = false;

    private void Start()
    {
        defaultPos = new Vector3(0, 55, -10);//�ʒu
        defaultLocate = new Vector3(0, 0, 0);//��]
        defaultScale = new Vector3(1, 1, 1);//�X�P�[��
    }
    public void ClickStartButton()
    {           // �J�n����
        switch (iineSlider.value)
        {         
            case 10:
                //isTimerStarted = true;
                GimimckCount += 1;
                if (GimimckCount <= 3)//3��M�~�b�N�\��
                {
                    Instantiate(myList[0]);
                    myList[0].transform.position = defaultPos;

                }
                iineSlider.value = 0;
                break;
            case 20:
                GimimckCount += 1;
                //isTimerStarted = true;
                if (GimimckCount <= 3)
                {
                    Instantiate(myList[1]);
                    myList[1].transform.position = defaultPos;
                }
                iineSlider.value = 0;
                break;
            case 30:
                //isTimerStarted = true;
                GimimckCount += 1;
                if (GimimckCount <= 3)
                {
                    Instantiate(myList[2]);
                    myList[2].transform.position = defaultPos;
                }
                iineSlider.value = 0;
                break;
        }
    }
    //void Update()
    //{
    //    // �^�C�}�[���J�n���Ă��Ȃ��ꍇ�͏��������Ȃ�
    //    if (isTimerStarted==true)
    //    {
    //        // �o�ߎ��Ԃ��v�Z�i���ݎ��� - �J�n���ԁj
    //        startTime = iineSlider.maxValue;
    //        startTime -= Time.deltaTime;

    //    if (startTime <= 0f)
    //    {
    //        isTimerStarted = false;
    //    }
    //}

    //}
}
