using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpui : MonoBehaviour
{
    Slider HpSlider;
    void Start() // Start is called before the first frame update
    {
        HpSlider = GetComponent<Slider>();
    }

    public void HPUI(float Hp)
    {
        HpSlider.value = Hp;
    }
}
