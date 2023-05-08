using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour , Attack
{
    [SerializeField] Transform firepos;
    [SerializeField] GameObject bullet;
    [SerializeField] 
    protected GameObject[] Item;

   
    [SerializeField]
    protected float Hp;
    public int Speed;
    
    Vector3 pos;


    protected bool isAttack = true;
    protected bool ismove = true;


    private void FixedUpdate()
    { 
        if(Hp <= 0)
        {
            Hp = 0;
        }
    }



    protected abstract  void Shoot();
    
    
    public void Attack(float damage)
    {
        
        if (isAttack == false && Hp > 0)
            return;
        Hp -= damage;
        isAttack = true;

    }
    
}
