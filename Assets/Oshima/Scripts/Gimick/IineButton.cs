using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class IineButton : MonoBehaviour
{
    public float IineButom;//�����˃{�^��
      public Slider _slider;//�����˃X���C�_�[
    // Start is called before the first frame update
    // Update is called once per frame
    public void Onclick()
    {    IineButom += 1;
        _slider.value = IineButom;
    }

}

