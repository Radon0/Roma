using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpui : MonoBehaviour
{     Slider HpSlider;
      GameObject CharacterGameobject;
    void Start() // Start is called before the first frame update
    {
        //CharacterGameobject.GetComponent<>().HpUiScript = GetComponent<Hpui>();
        //キャラクターのコンポーネントを入れて
        HpSlider = GetComponent<Slider>();
        HpSlider.value = 3;
    }

    public void HPUI(int Damege)
    {
        HpSlider.value -= Damege;
        if (HpSlider.value == 0)
        {
            Destroy(gameObject);
        }
    }
}
