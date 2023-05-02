using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField]
    float speed;
    float timer = 0;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float ClampX = Mathf.Clamp(transform.position.x + x * Time.deltaTime * speed, -2.7f, 2.7f);
        float y = Input.GetAxisRaw("Vertical");
        float ClampY = Mathf.Clamp(transform.position.y + y * Time.deltaTime * speed, -5f, 5f);
        Vector2 curpos = transform.position;
        //        transform.position = curpos + (new Vector2(x, y).normalized * Time.deltaTime) * speed;
        transform.position = new Vector2(ClampX, ClampY);
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
    
}
