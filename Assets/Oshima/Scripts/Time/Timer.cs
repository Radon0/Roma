using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float startTime;
    bool isTimerStarted = false;

    public void OnClick()
    {
        // 開始時間
        startTime = Time.time;

        // タイマーが開始したかどうか
        isTimerStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        // タイマーが開始していない場合は処理をしない
        if (!isTimerStarted)
        {
            return;
        }

        // 経過時間を計算（現在時間 - 開始時間）
        float passedTime = startTime-Time.time;

        if (passedTime < 0f)
        {
            isTimerStarted = false;
        }

    }
}
