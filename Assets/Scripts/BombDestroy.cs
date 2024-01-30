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
            //�G�t�F�N�g�𐶐�����
            GameObject effect = Instantiate(ExploadObj) as GameObject;
            //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
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
