using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyM : Enemy
{
    Collider2D player;
    [SerializeField]
    float timer = 0;
    Vector3 pos;

    [SerializeField] Sprite[] img;
    SpriteRenderer spr;
    float curHp;
    private void OnEnable()
    {
        
        Hp = 5f;
        curHp = Hp;
        Speed = 3;
    }
    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        Hp = 5f;
        curHp = Hp;
        Speed = 3;
    }
    private void FixedUpdate()
    {
        player = Physics2D.OverlapCircle(transform.position, 15f, LayerMask.GetMask("Player"));
        timer += Time.deltaTime;
        Shoot();
        if (curHp > Hp && Hp > 1)
        {
            StartCoroutine(imgchange());
            
        }
        else if (Hp <= 0)
        {
            spr.sprite = img[2];

            Die();

        }
        
            

    }
    protected override void Shoot()
    {
        if (player != null && timer > 2f)
        {
            timer = 0;
            GameObject obj = Objectpool.Instance.EnmeybulleObject();
            obj.transform.position = transform.position;
            obj.SetActive(true);
            pos = player.transform.position - obj.transform.position;
            obj.GetComponent<Rigidbody2D>().velocity = pos.normalized * 3f;
            obj.transform.SetParent(null);

        }
    }
    void Die()
    {
        GameObject obj = Instantiate(Item[Random.Range(0, 3)], transform.position, Quaternion.identity);
        Objectpool.Instance.EnemyMreturn(gameObject);
    }
    IEnumerator imgchange()
    {
        spr.sprite = img[1];
        curHp = Hp;
        yield return new WaitForSeconds(0.2f);
        spr.sprite = img[0];
    }


}
