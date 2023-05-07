using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Collider2D enemy;
    [SerializeField]
    Sprite[] sp;
    SpriteRenderer spr;

    private void OnEnable()
    {
       /* StartCoroutine(bulletlifespan());*/
    }

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position += Vector3.up * 5f * Time.deltaTime;
        enemy = Physics2D.OverlapCircle(transform.position, this.GetComponent<BoxCollider2D>().size.y, LayerMask.GetMask("Enemy"));
        
        Attack();
    }

    private void FixedUpdate()
    {
        if(Objectpool.Instance.Player.GetComponent<Player>().power == 0)
        {
            spr.sprite = sp[0];
        }
        if (Objectpool.Instance.Player.GetComponent<Player>().power == 1)
        {
            spr.sprite = sp[1];
        }
        if (Objectpool.Instance.Player.GetComponent<Player>().power == 2)
        {
            spr.sprite = sp[2];
        }
    }

    void Attack()
    {
        if (enemy != null)
        {
            if(enemy.GetComponent<EnemyS>())
            {
                enemy.GetComponent<EnemyS>().Attack(1+Objectpool.Instance.Player.GetComponent<Player>().power);
            }
            else if (enemy.GetComponent<EnemyM>())
            {
                enemy.GetComponent<EnemyM>().Attack(1+ Objectpool.Instance.Player.GetComponent<Player>().power);
            }
            /*else if (enemy.GetComponent<EnemyL>())
            {
                enemy.GetComponent<EnemyL>().Attack(1);
            }*/


            Objectpool.Instance.ReturnObject(gameObject);
            transform.SetParent(Objectpool.Instance.PlayerFirepos.transform);
            transform.position = Objectpool.Instance.PlayerFirepos.transform.position;
            gameObject.SetActive(false);
        }
    }
    
   

    
}
