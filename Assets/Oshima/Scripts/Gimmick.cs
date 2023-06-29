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
    public List<GameObject> myList = new List<GameObject>();//一応複数のギミックをやれるようにはしている        
    private int GimimckCount;//ギミックの表示回数
    public float startTime;
    public bool isTimerStarted = false;

    private void Start()
    {
        defaultPos = new Vector3(0, 55, -10);//位置
        defaultLocate = new Vector3(0, 0, 0);//回転
        defaultScale = new Vector3(1, 1, 1);//スケール
    }
    public void ClickStartButton()
    {           // 開始時間
        switch (iineSlider.value)
        {         
            case 10:
                //isTimerStarted = true;
                GimimckCount += 1;
                if (GimimckCount <= 3)//3回ギミック表示
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
    //    // タイマーが開始していない場合は処理をしない
    //    if (isTimerStarted==true)
    //    {
    //        // 経過時間を計算（現在時間 - 開始時間）
    //        startTime = iineSlider.maxValue;
    //        startTime -= Time.deltaTime;

    //    if (startTime <= 0f)
    //    {
    //        isTimerStarted = false;
    //    }
    //}

    //}
}
