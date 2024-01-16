using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove : MonoBehaviour
{
	[SerializeField]
	[Tooltip("対象物(向く方向)")]
	private GameObject target;

	[SerializeField]
	[Tooltip("対象物を向くまでのスピード[0-1](値が小さいほど向くまでのスピードが遅い")]
	private float speed;

 ////   private void Start()
 ////   {
	////	transform.rotation = Quaternion.Euler(0f, 112f, 0f);
	////}
    void Update()
	{
		// 対象物と自分自身の座標からベクトルを算出してQuaternion(回転値)を取得
		Vector3 vector3 = target.transform.position - this.transform.position;
		
		vector3.y = 0f;
		//transform.rotation = Quaternion.Euler(0f, 112f, 0f);
		// Quaternion(回転値)を取得
		Quaternion quaternion = Quaternion.LookRotation(vector3);
	
		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, quaternion, speed);
	}


}
