using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    //public ParticleSystem effect;
    public GameObject ExploadObj;

    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();


    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            audio.Play();
            //エフェクトを生成する
            GameObject effect = Instantiate(ExploadObj) as GameObject;
            //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
            effect.transform.position = gameObject.transform.position;

            Destroy(this.gameObject);

        }
    }
    //public void PlayExplode()
    //{
    //    //currentEffect.SetActive(true);
    //    effect.Play();
    //}


    //public bool playEffect;
    //private void OnValidate()
    //{
    //    if (!playEffect) return;
    //    playEffect = false;

    //    this.PlayExplode();
    //}
}
