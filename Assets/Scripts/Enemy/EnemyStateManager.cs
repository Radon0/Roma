using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    public enum EnemyState
    {
        Wait,
        Move,
        Attack,
        Escape,
        Dead
    };

    EnemyState enemyState;
    HPController hpController;
    public bool isDead=false;

    private int EnemyHp = 0;
    private int maxHp = 10;

    public int EnemyHpControll
    {
        set
        {
            EnemyHp = Mathf.Clamp(value, 0, maxHp);
        }
        get
        {
            return EnemyHp;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyState = EnemyState.Wait;
    }

    // Update is called once per frame
    void Update()
    {
        if (hpController.Hp == 0)
        {
            enemyState = EnemyState.Dead;
            isDead = true;
            return;
        }
    }
}
