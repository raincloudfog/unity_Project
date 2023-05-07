using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("enemy"))
        {
            Objectpool.Instance.Enemyreturn(collision.gameObject);
            
        }
        else if (collision.CompareTag("bullet"))
        {
            
            Objectpool.Instance.ReturnObject(collision.gameObject);
            collision.transform.SetParent(Objectpool.Instance.PlayerFirepos.transform);
            collision.transform.position = Objectpool.Instance.PlayerFirepos.transform.position;
            collision.gameObject.SetActive(false);
        }
    }
}
