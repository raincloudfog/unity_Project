using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyL : Enemy
{
    protected override void Shoot()
    {
        throw new System.NotImplementedException();
    }

    private void OnEnable()
    {
        Hp = 10;
        Speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
