using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        // ゲームオブジェクトの初期位置と回転を記録
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        // LateUpdate()メソッドを使うことで、他のスクリプトによる変更があってもこのスクリプトが最後に処理される
        // これにより、位置と回転が変更されないようになる
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
