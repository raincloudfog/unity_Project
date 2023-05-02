using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Collider2D enemy;
    private void OnEnable()
    {
        StartCoroutine(bulletlifespan());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * 3f * Time.deltaTime;
        enemy = Physics2D.OverlapCircle(transform.position, this.GetComponent<BoxCollider2D>().size.y, LayerMask.GetMask("Enemy"));
        
        Attack();
    }

    void Attack()
    {
        if (enemy != null)
        {
            if(enemy.GetComponent<EnemyS>())
            {
                enemy.GetComponent<EnemyS>().Attack(1);
            }
            else if (enemy.GetComponent<EnemyM>())
            {
                enemy.GetComponent<EnemyM>().Attack(1);
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
    
    IEnumerator bulletlifespan()
    {
        yield return new WaitForSeconds(2f);
        Objectpool.Instance.ReturnObject(gameObject);
        transform.SetParent(Objectpool.Instance.PlayerFirepos.transform);
        transform.position = Objectpool.Instance.PlayerFirepos.transform.position;
        gameObject.SetActive(false);
    }
}
