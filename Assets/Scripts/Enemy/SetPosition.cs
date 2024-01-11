using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    //プレイヤーのオブジェクト
    public GameObject playerObj;
    //初期位置
    private Vector3 startPosition;
    //目的地
    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        //初期位置を設定
        startPosition = transform.position;
        SetDestination(transform.position);
    }


    private void Update()
    {
        destination.x = playerObj.transform.position.x;
        destination.y = this.transform.position.y;
        destination.z = playerObj.transform.position.z;
    }

    //目的地を設定する
    public void SetDestination(Vector3 position)
    {
        destination = position;
    }

    //目的地を取得する
    public Vector3 GetDestination()
    {
        return destination;
    }
}
