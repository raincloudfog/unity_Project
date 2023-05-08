using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyL : Enemy
{
    float timer = 0;
    Collider2D plyaer;
    [SerializeField] Sprite[] img;
    SpriteRenderer spr;

    float curHp;
    protected override void Shoot()
    {
        float j = -0.3f;
        
        for (int i = 0; i < 2; i++)
        {
            GameObject obj;
            obj = Objectpool.Instance.EnmeybulleObject();

            obj.transform.position = transform.position + new Vector3(j, 0, 0);

            obj.GetComponent<Rigidbody2D>().velocity = Vector3.down * 3f;

            obj.transform.SetParent(null);
            j += 1;
        }

        
        timer = 0;




    }

    private void OnEnable()
    {
        Hp = 10;
        curHp = Hp;
        Speed = 1;
    }

    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        Hp = 10;
        curHp = Hp;
        Speed = 1;
    }
    private void Start()
    {
        Shoot();
    }

    private void FixedUpdate()
    {
        plyaer = Physics2D.OverlapCircle(transform.position, 20f);

        timer += Time.deltaTime;
        if(timer >= 2f)
        {
            Shoot();
        }

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
    IEnumerator imgchange()
    {
        spr.sprite = img[1];
        curHp = Hp;
        yield return new WaitForSeconds(0.2f);
        spr.sprite = img[0];
    }

    void Die()
    {
        GameObject obj = Instantiate(Item[Random.Range(0, 3)], transform.position, Quaternion.identity);
        Objectpool.Instance.EnemyMreturn(gameObject);
    }

}
