using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpHealing : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject enemyObj;
    public Hpui hpUI;

    private HPController playerHpController;
    private HPController enemyHpController;
    private bool playerHealable;
    private bool enemyHealable;
    [SerializeField]
    private LogInfomation logSystem;

    // Start is called before the first frame update
    void Start()
    {
        playerHealable = false;
        enemyHealable = false;
        playerHpController = playerObj.GetComponent<HPController>();
        enemyHpController = enemyObj.GetComponent<HPController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerHealable = true;
            Destroy(this.gameObject);
            Healing(playerHpController,10);
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            enemyHealable = true;
            Destroy(this.gameObject);
        }
    }
    private void Healing(HPController hpController,float healingValue)
    {
        hpController.Hp += healingValue;
        hpUI.HPUI(hpController.Hp);
        if (hpController.Hp>hpController.maxHp)
        {
            hpController.Hp = hpController.maxHp;
        }
    }
}
