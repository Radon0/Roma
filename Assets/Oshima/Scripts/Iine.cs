using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Iine : MonoBehaviour
{
    // Start is called before the first frame update
    Slider IineSlider;
    GameObject CharacterGameobject;
    void Start() // Start is called before the first frame update
    {
        CharacterGameobject = GameObject.FindWithTag("IineButton").GetComponent<IineButton>().iineObject;
        CharacterGameobject.GetComponent<IineButton>().IineScript = GetComponent<Iine>();
        IineSlider = GetComponent<Slider>();
        IineSlider.value = 10;
    }

    public void Iinesu(float IineButom)
    {
        IineSlider.value = IineButom;
    }
}

