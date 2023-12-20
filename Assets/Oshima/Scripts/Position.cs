using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Position : MonoBehaviour
{
    private Vector3 _initialPosition; // �����ʒu
    private Quaternion _initialRotation; // ������]
    public Ready ready;
    HPController hP;
   
    void Start()
    {
        hP = GetComponent<HPController>();
        // �����ʒu�E������]�̎擾
        _initialPosition = gameObject.transform.position;
        _initialRotation = gameObject.transform.rotation;
    }
    private void Update()
    {
        if (ready.winLose == true)
        {
           
            Invoke("Reset",6f);
        
        }
        if (Input.GetKeyDown("r")) //����if����ǋL
        {
            SceneManager.LoadScene(2);
        }

    }

    // �������֐�
    public void Reset()
    {
        ready.totalTime = 90;
        hP.isDead = false;
       hP.Hp=100;
        gameObject.transform.position = _initialPosition; // �ʒu�̏�����
        gameObject.transform.rotation = _initialRotation; // ��]�̏�����
        ready.Round = false;
    }
}

