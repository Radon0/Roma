using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Position : MonoBehaviour
{
    private Vector3 _initialPosition; // 初期位置
    private Quaternion _initialRotation; // 初期回転
    public Ready ready;
    HPController hP;
   
    void Start()
    {
        hP = GetComponent<HPController>();
        // 初期位置・初期回転の取得
        _initialPosition = gameObject.transform.position;
        _initialRotation = gameObject.transform.rotation;
    }
    private void Update()
    {
        if (ready.winLose == true)
        {
           
            Invoke("Reset",6f);
        
        }
        if (Input.GetKeyDown("r")) //このif文を追記
        {
            SceneManager.LoadScene(2);
        }

    }

    // 初期化関数
    public void Reset()
    {
        ready.totalTime = 90;
        hP.isDead = false;
       hP.Hp=100;
        gameObject.transform.position = _initialPosition; // 位置の初期化
        gameObject.transform.rotation = _initialRotation; // 回転の初期化
        ready.Round = false;
    }
}

