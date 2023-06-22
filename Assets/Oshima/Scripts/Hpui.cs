using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpui : MonoBehaviour
{
    Slider HpSlider;
    GameObject CharacterGameobject;
    void Start() // Start is called before the first frame update
    {
        CharacterGameobject = GameObject.FindWithTag("Player").GetComponent<HPController>().HPObject;
        CharacterGameobject.GetComponent<HPController>().HpuiScript = GetComponent<Hpui>();
        HpSlider = GetComponent<Slider>();
        HpSlider.value = 10;//HP‚Æ“¯‚¶—Ê‚É‚·‚é
    }

    public void HPUI(float Hp)
    {
        HpSlider.value = Hp;
    }
}
