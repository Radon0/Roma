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
    public Image[] parentVictoryMarks; // 親オブジェクトの勝利マークのImageコンポーネントの配列
    public Ready player1Wins; // プレイヤー1の勝利回数
    private void Start()
    {  
        //ResetVictoryDisplay();
        //winsCount = player1Wins.WinCount;
    }
    // 勝利マークをリセットするメソッド
    //private void ResetVictoryDisplay()
    //{
    //    winsCount = 0;

    //    // すべての親オブジェクトの勝利マークを非表示にする
    //    foreach (var mark in parentVictoryMarks)
    //    {
    //        mark.enabled = false;
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
        //        }
        //    WinMark[0].SetActive(true);
        //    if (player1Wins.WinCount == 2)
        //    {
        //        WinMark[1].SetActive(true);
        //    }
        //}
        //if (player1Wins.LoseCount == 1)
        //{
        //    WinMark[2].SetActive(true);
        //    if (player1Wins.LoseCount == 2)
        //    {
        //        WinMark[3].SetActive(true);
        //    }
        //}

        //else if (player1Wins.LoseCount < 1)
        //{
        //    player2WinMark.SetActive(false);
        //}
        // if (player1Wins.WinCount == 3)
        //{
        //    // BO3で勝利した場合の処理を行う（例: ゲーム終了処理、勝利表示など）
        //}
        // else if (player1Wins.LoseCount == 3)
        //{

        //}
    }
}
