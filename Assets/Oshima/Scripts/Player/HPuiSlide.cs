using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPuiSlide : MonoBehaviour
{
    Slider HpSlider;
    private Image _image;
    void Start() // Start is called before the first frame update
    {
        _image = this.GetComponent<Image>();
    }

    public void HPUI(float Hp)
    {
        HpSlider.value = Hp;

    }

}
