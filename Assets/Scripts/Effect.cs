using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public ParticleSystem effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayEffect();
    }
    public void PlayEffect()
    {
        //currentEffect.SetActive(true);
        effect.Play();
    }


    public bool playEffect;
    private void OnValidate()
    {
        if (!playEffect) return;
        playEffect = false;

        this.PlayEffect();
    }
}
