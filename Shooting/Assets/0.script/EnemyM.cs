using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyM : Enemy
{
    private void OnEnable()
    {
        Hp = 10f;
        Speed = 3;
    }
    void Awake()
    {
        Hp = 10f;
        Speed = 3;
    }

    
}
