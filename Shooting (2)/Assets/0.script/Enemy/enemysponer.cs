using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemysponer : MonoBehaviour
{
    [SerializeField] GameObject[] Enemys;
    Queue<GameObject> listenemy = new Queue<GameObject>();
    bool turn = true; // 커브 허락하는 불값
    int i = 0;
    int j = 0;

    void Start()
    {
        StartCoroutine(spon());
    }

    IEnumerator spon()
    {
        yield return new WaitForSeconds(2f);
        while (i < 5)
        {
            yield return new WaitForSeconds(0.4f);
            GameObject obj = Objectpool.Instance.EnemyObject();
            obj.transform.position = new Vector3(2, 0, 0) + transform.position;
            obj.GetComponent<Rigidbody2D>().velocity = Vector2.down * obj.GetComponent<EnemyS>().Speed;
            i++;
        }
        
        
        yield return new WaitForSeconds(2f);
        while(j < 5)
        {
            yield return new WaitForSeconds(0.4f);
            GameObject obj = Objectpool.Instance.EnemyObject();
            obj.transform.position = new Vector3(-2, 0, 0) + transform.position;
            obj.GetComponent<Rigidbody2D>().velocity = Vector2.down * obj.GetComponent<EnemyS>().Speed;


            j++;
        }
        i = 0;
        j = -2;
        yield return new WaitForSeconds(2f);
        while(i < 3)
        {

            GameObject obj = Objectpool.Instance.EnemyMObject();
            obj.transform.position = new Vector3(j, transform.position.y, 0) ;
            obj.GetComponent<Rigidbody2D>().velocity = Vector2.down * obj.GetComponent<EnemyM>().Speed;
            j += 2;

            
            i++;
        }
        i = 0;
        j = -2;
        yield return new WaitForSeconds(5f);
        {
            while (i < 2)
            {
                GameObject obj = Objectpool.Instance.EnemyLObject();
                obj.transform.position = new Vector3(j, transform.position.y, 0);
                obj.GetComponent<Rigidbody2D>().velocity = Vector2.down* obj.GetComponent<EnemyL>().Speed;
                /*if(obj.transform.position.x >= Camera.main.aspect)
                {
                    obj.GetComponent<Rigidbody2D>().velocity = Vector2.down * obj.GetComponent<EnemyL>().Speed;
                    
                }*/
                turn = false;
                j += 3;
                i++;
            }
        }
        yield return new WaitForSeconds(5f);
        {
            GameObject obj = Objectpool.Instance.BossCreate();
            obj.transform.position = transform.position;
            obj.GetComponent<Rigidbody2D>().velocity = Vector3.down * obj.GetComponent<Boss>().Speed;
        }
        
        
    }
}
