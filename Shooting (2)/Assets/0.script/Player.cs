using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigid;
    [SerializeField]
    float speed;
    float timer = 0;
   
    public int power = 0;
    Collider2D item;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        

        item = Physics2D.OverlapCircle(transform.position,
            this.GetComponent<CapsuleCollider2D>().size.y, LayerMask.GetMask("item"));
        Move();
        Shoot();
        Getitem();

    }
    private void FixedUpdate()
    {
        if(power >= 2)
        {
            power = 2;
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float ClampX = Mathf.Clamp(transform.position.x + x * Time.deltaTime * speed, -2.7f, 2.7f);
        float y = Input.GetAxisRaw("Vertical");
        float ClampY = Mathf.Clamp(transform.position.y + y * Time.deltaTime * speed, -5f, 5f);
        //Vector2 curpos = transform.position;        
        //        transform.position = curpos + (new Vector2(x, y).normalized * Time.deltaTime) * speed;
        transform.position = new Vector2(ClampX, ClampY);
        anim.SetFloat("Float X", x);
    }

    void Shoot()
    {
        timer += Time.deltaTime;
        if(Input.GetKey(KeyCode.C) && timer > 0.2)
        {
            timer = 0;
            if (Objectpool.Instance.CheckPool())
            {
                Objectpool.Instance.Create();
            }
            Objectpool.Instance.playObject();
        }
    }

    void Getitem()
    {
        

        if(item != null)
        {
            if (item.CompareTag("power"))
            {
                power++;
                
            }
            Destroy(item.gameObject);
        }
        
        
        
    }
    
}
