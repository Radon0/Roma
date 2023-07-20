using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpHealing : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject enemyObj;
    public HPController playerHpController;
    public HPController enemyHpController;

    private bool playerHealable;
    private bool enemyHealable;

    // Start is called before the first frame update
    void Start()
    {
        playerHealable = false;
        enemyHealable = false;
        //playerObj = GameObject.Find("Player");
        //enemyObj = GameObject.Find("Enemy");
        playerHpController = playerObj.GetComponent<HPController>();
        enemyHpController = enemyObj.GetComponent<HPController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealable)
        {
            Healing(playerHpController);
            Debug.Log("player‚ÌHP‚ª‰ñ•œ‚µ‚½I");
        }
        if (enemyHealable)
            Healing(enemyHpController);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            playerHealable = true;
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag=="Enemy")
        {
            enemyHealable = true;
            Destroy(this.gameObject);
        }
    }
    private void Healing(HPController hpController)
    {
        hpController.Hp += 10;
        if(hpController.Hp>10)
        {
            hpController.Hp = 10;
        }
    }
}
