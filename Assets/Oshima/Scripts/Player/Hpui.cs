using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpui : MonoBehaviour
{
     //Slider HpSlider;
    private Image _image;
    void Start() // Start is called before the first frame update
    {
        //HpSlider = GetComponent<Slider>();
        _image = this.GetComponent<Image>();
    }

    public void HPUI(float Hp)
    {
        //HpSlider.value = Hp;
        _image.fillAmount = Hp / 100f;
    }
}
