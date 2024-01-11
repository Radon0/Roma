using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gimmick : MonoBehaviour
{
    [SerializeField] Slider iineSlider;
    public bool click = false;// クリックした位置座標
    public Button button;
    public bool Open = false;
    public Tap tap;
    private void Start()
    {
        button = GetComponent<Button>();
    }
    public void ClickStartButton()
    {
        if (iineSlider.value == iineSlider.maxValue && tap.click == false)
        {
            button.interactable = false;
            click = true;
            Open = true;
            Invoke("DisableButton", 0.0001f);
        }
    }
    private void DisableButton()
    {
        Open = false;
    }
}
