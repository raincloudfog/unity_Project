using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform firepos;
    [SerializeField] GameObject bullet;
    Collider2D player;
    protected int Hp;
    protected int Speed;
    GameObject obj;
    Vector3 pos;
    float timer = 0;

    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        player = Physics2D.OverlapCircle(transform.position, 10f, LayerMask.GetMask("Player"));
        this.GetComponent<Rigidbody2D>().velocity = Vector2.down;
        Shoot();

        
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
            obj.transform.SetParent(null);
            pos = player.transform.position - obj.transform.position;
        }
        obj.GetComponent<Rigidbody2D>().velocity = pos.normalized *  3f;
        
        return;
    }
    
}
