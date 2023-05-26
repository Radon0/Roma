using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IineButton : MonoBehaviour
{
    public float IineButom;//いいねボタン
    public GameObject iineObject;//HPuiのゲームオブジェクト
    public Iine IineScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Onclick()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            IineButom += 1;
            IineScript.Iinesu(IineButom);


        }
    }

}

