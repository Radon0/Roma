using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BO3Maneger : MonoBehaviour
{
    //public int winsNeeded = 2; // BO3形式なので2勝必要
    public GameObject[] WinMark; // プレイヤー1の勝利マーク
    //public GameObject player2WinMark; // プレイヤー2の勝利マーク
    //private int winsCount = 0;
    //public Image[] parentVictoryMarks; // 親オブジェクトの勝利マークのImageコンポーネントの配列
    public Ready player1Wins; // プレイヤー1の勝利回数
    private void Start()
    {
        //ResetVictoryDisplay();

    }
    // 勝利マークをリセットするメソッド
    //private void ResetVictoryDisplay()
    //{
    //    player1Wins.WinCount = 0;

    //    // すべての親オブジェクトの勝利マークを非表示にする
    //    foreach (var mark in parentVictoryMarks)
    //    {
    //        mark.enabled = false;
    //    }
    //}
    //public void AddWin()
    //{
    //    if (player1Wins.WinCount < 0)
    //    {
    //        parentVictoryMarks[player1Wins.WinCount].enabled = true;
         
    //    }

    //}
    public void Update()
    {


        switch (player1Wins.WinCount)//勝った時
        {
            case 1:
                {
                    WinMark[0].SetActive(true);
                    break;
                }
            case 2:
                {
                    WinMark[1].SetActive(true);
                    break;
                }
        }
        switch (player1Wins.LoseCount)//負けた時
        {
            case 1:
                {
                    WinMark[2].SetActive(true);
                    break;

                }
            case 2:
                {
                    WinMark[3].SetActive(true);
                    break;
                }
        }
    }
}
