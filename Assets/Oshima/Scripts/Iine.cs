using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Iine : MonoBehaviour
{
    Slider IineSlider;
    public float timer;
    bool time=false;
    
    // Start is called before the first frame update
    void Start()
    {
        IineSlider = GetComponent<Slider>();       
    }
    // Update is called once per frame
    void Update()
    {
        if (time == false)
        {
            timer += Time.deltaTime;
            IineSlider.value = timer;

            if (IineSlider.maxValue < timer)
            {
                time = true;
            }

        }
    }
}
