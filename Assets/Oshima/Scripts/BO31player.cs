using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BO31player : MonoBehaviour
{

    public Image[] childVictoryMarks; // 子オブジェクトの勝利マークのImageコンポーネントの配列

    public Ready player1Wins; // プレイヤー1の勝利回数
    private int winsCount = 0;
    private void Start()
    {
        ResetVictoryDisplay();
        winsCount = player1Wins.WinCount;
    }

    // 勝利マークをリセットするメソッド
    private void ResetVictoryDisplay()
    {
        winsCount = 0;


        // すべての子オブジェクトの勝利マークを非表示にする
        foreach (var mark in childVictoryMarks)
        {
            mark.enabled = false;
        }
    }

    // 勝利回数を増やして子オブジェクトの勝利マークを表示するメソッド
    public void Update()
    {
        if (winsCount < childVictoryMarks.Length)
        {
            childVictoryMarks[winsCount].enabled = true;
            winsCount++;
        }
    }
}
