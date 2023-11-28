using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class IineButton : MonoBehaviour
{
    public float IineButom;//いいねボタン
      public Slider _slider;//いいねスライダー
    // Start is called before the first frame update
    // Update is called once per frame
    public void Onclick()
    {    IineButom += 1;
        _slider.value = IineButom;
    }

}

