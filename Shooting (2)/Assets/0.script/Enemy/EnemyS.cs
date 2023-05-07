using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS : Enemy
{
    [SerializeField]
    float timer = 0;
    [SerializeField] Sprite[] img;
    SpriteRenderer spr;
    Collider2D player;
    float curHp;

    Vector3 pos;

    private void OnEnable()
    {
        spr.sprite = img[0];
        Hp = 3;
        curHp = Hp;
        Speed = 2;
    }
    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        Hp = 3;
        curHp = Hp;
        Speed = 2;
    }

    private void FixedUpdate()
    {
        Shoot();
        player = Physics2D.OverlapCircle(transform.position, 15f, LayerMask.GetMask("Player"));
        timer += Time.deltaTime;
        if (curHp > Hp)
        {
            StartCoroutine(imgchange());

        }
        else if (Hp <= 0)
        {
            spr.sprite = img[2];
            GameObject obj = Instantiate(Item[Random.Range(0, 3)], transform.position, Quaternion.identity);
            Objectpool.Instance.EnemySreturn(gameObject);
        }
            
    }

    IEnumerator imgchange()
    {
        spr.sprite = img[1];
        curHp = Hp;
        yield return new WaitForSeconds(0.2f);
        spr.sprite = img[0];
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

    /*void turn()
    {
        if (transform.position.x > 2.7)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f ,-Mathf.Deg2Rad * 45) * Speed;
        }
    }*/
}
