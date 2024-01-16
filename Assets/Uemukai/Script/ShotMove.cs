using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove : MonoBehaviour
{
	[SerializeField]
	[Tooltip("�Ώە�(��������)")]
	private GameObject target;

	[SerializeField]
	[Tooltip("�Ώە��������܂ł̃X�s�[�h[0-1](�l���������قǌ����܂ł̃X�s�[�h���x��")]
	private float speed;

 ////   private void Start()
 ////   {
	////	transform.rotation = Quaternion.Euler(0f, 112f, 0f);
	////}
    void Update()
	{
		// �Ώە��Ǝ������g�̍��W����x�N�g�����Z�o����Quaternion(��]�l)���擾
		Vector3 vector3 = target.transform.position - this.transform.position;
		
		vector3.y = 0f;
		//transform.rotation = Quaternion.Euler(0f, 112f, 0f);
		// Quaternion(��]�l)���擾
		Quaternion quaternion = Quaternion.LookRotation(vector3);
	
		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, quaternion, speed);
	}


}
