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
        Escape
    };

    EnemyState enemyState;

    // Start is called before the first frame update
    void Start()
    {
        enemyState = EnemyState.Wait;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
