using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS : Enemy
{
    private void OnEnable()
    {
        Hp = 5;
        Speed = 1;
    }
    private void Awake()
    {
        Hp = 5;
        Speed = 1;
    }

    private void FixedUpdate()
    {
        turn();
    }
    void turn()
    {
        if (transform.position.x > 2.7)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f ,-Mathf.Deg2Rad * 45) * Speed;
        }
    }
}
