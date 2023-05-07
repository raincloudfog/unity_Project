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
    

    bool isAttack = true;


    private void FixedUpdate()
    {
        
       
        
        
        if(Hp <= 0)
        {
            Hp = 0;
        }
    }



    protected abstract  void Shoot();
    
        /*if (player != null && timer > 2f)
        {
            timer = 0;
            GameObject obj = Objectpool.Instance.EnmeybulleObject();
            obj.transform.position = transform.position;
            obj.SetActive(true);
            pos = player.transform.position - obj.transform.position;
            obj.GetComponent<Rigidbody2D>().velocity = pos.normalized * 3f;
            obj.transform.SetParent(null);
           
        }*/



    

    public void Attack(float damage)
    {
        if (isAttack == false && Hp > 0)
            return;
        Hp -= damage;
        isAttack = true;

    }
    
}
