using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour , Attack
{
    [SerializeField] Transform firepos;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject[] Item;

    Collider2D player;
    protected float Hp;
    public int Speed;
    GameObject obj;
    Vector3 pos;
    float timer = 0;

    private void FixedUpdate()
    {
        player = Physics2D.OverlapCircle(transform.position, 10f, LayerMask.GetMask("Player"));
        
        Shoot();
        Die();
        
    }
    
    void Die()
    {
        if(Hp <= 0)
        {
            GameObject obj =  Instantiate(Item[Random.Range(0,3)], transform.position, Quaternion.identity);
            Objectpool.Instance.Enemyreturn(gameObject);
        }
    }

    void Shoot()
    {
        timer += Time.deltaTime;
        if (player != null && timer > 5f)
        {
            timer = 0;
            

            obj = Objectpool.Instance.EnmeybulleObject();
            obj.transform.position = transform.position;
            obj.SetActive(true);
            pos = player.transform.position - obj.transform.position;
            obj.GetComponent<Rigidbody2D>().velocity = pos.normalized * 3f;
            obj.transform.SetParent(null);
           
        }
        
        
        return;
    }

    public void Attack(float damage)
    {
        
        Hp -= damage;
        
    }
}
