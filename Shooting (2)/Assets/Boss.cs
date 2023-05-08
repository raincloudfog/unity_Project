using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    Collider2D player;
    Rigidbody2D rigid;
    float timer = 0;
    Vector3 pos;
    Transform firepos;
    float angle = 0;
    float plusangle = 15;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Hp = 50f;
        Speed = 1;
        
    }

    private void Start()
    {
        StartCoroutine(petton());
    }
    protected override void Shoot()
    {
        throw new System.NotImplementedException();
    }
    private void FixedUpdate()
    {
        player = Physics2D.OverlapCircle(transform.position, 20f);

        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            ismove = false;
            rigid.velocity = Vector2.zero;
            
        }
    }

    IEnumerator petton()
    {
        while(true)
        {
            int i = 0;
            yield return new WaitForSeconds(2f);
            while (i < 20)
            {
                //yield return new WaitForSeconds(0.1f);
                {
                    //yield return new WaitForSeconds(0.8f);
                    GameObject obj = Objectpool.Instance.EnmeybulleObject();
                    obj.transform.position = transform.GetChild(0).position;
                    obj.GetComponent<Rigidbody2D>().velocity =
                        new Vector2(-angle * Mathf.Deg2Rad, -1) * 3f;
                    angle += plusangle;
                    if (angle >= 90 || angle <= -90)
                        plusangle *= -1;
                    i++;
                }
            }
            i = 0;
            yield return new WaitForSeconds(2f);
            while(i < 20)
            {
                yield return new WaitForSeconds(0.1f);
                {
                    //yield return new WaitForSeconds(0.8f);
                    GameObject obj = Objectpool.Instance.EnmeybulleObject();
                    obj.transform.position = transform.GetChild(0).position;
                    obj.GetComponent<Rigidbody2D>().velocity =
                        new Vector2(-angle * Mathf.Deg2Rad, -1) * 3f;
                    angle += plusangle;
                    if (angle >= 90 || angle <= -90)
                        plusangle *= -1;
                    i++;
                }
                
            }
            i = 0;
            yield return new WaitForSeconds(2f);
            for (int j = 0; j < 360; j += 360/12)
            {
                //yield return new WaitForSeconds(0.8f);
                GameObject obj = Objectpool.Instance.EnmeybulleObject();
                obj.transform.position = transform.GetChild(0).position;
                obj.GetComponent<Rigidbody2D>().velocity =
                    new Vector2(j * Mathf.Deg2Rad, j * Mathf.Deg2Rad) * 3f;
            }
            
        }
        
        
    }
}
