using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectpool : Singleton<Objectpool>
{

    public GameObject Player;
    public GameObject PlayerFirepos;

    public GameObject[] Enemys;

    [SerializeField] GameObject[] bullet;
    [SerializeField] GameObject[] Enemybullet;
    

    Queue<GameObject> pools = new Queue<GameObject>();
    Queue<GameObject> Enemybulletpools = new Queue<GameObject>();
    Queue<GameObject> EnemySpools = new Queue<GameObject>();
    Queue<GameObject> EnemyMpools = new Queue<GameObject>();
    Queue<GameObject> EnemyLpools = new Queue<GameObject>();


    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public bool CheckPool()
    {
        if(pools.Count == 0)
        {
            return true;
        }
        return false;
    }

    public void Create()
    {
        GameObject obj = Instantiate(bullet[0], PlayerFirepos.transform);

        pools.Enqueue(obj);
    }

    public void ReturnObject(GameObject obj)
    {
        pools.Enqueue(obj);
        
        
    }
    public void playObject()
    {
        GameObject obj = pools.Dequeue();
        obj.SetActive(true);
        obj.transform.SetParent(null);
    }

    public bool CheckEnmeybulletPool()
    {
        if (Enemybulletpools.Count == 0)
        {
            return true;
        }
        return false;

    }

    public void EnmeybulleCreate()
    {
        GameObject obj = Instantiate(Enemybullet[0], transform);

        Enemybulletpools.Enqueue(obj);
    }

    public void EnmeybulleReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        Enemybulletpools.Enqueue(obj);


    }
    public GameObject EnmeybulleObject()
    {
        if (Instance.CheckEnmeybulletPool())
        {
            Instance.EnmeybulleCreate();
        }
        GameObject obj = Enemybulletpools.Dequeue();
        
        //obj.transform.position = obj.transform.parent.position;
        

        return obj;
    }

    public bool CheckEnemypoos()
    {
        if(EnemySpools.Count == 0)
        {
            return true;
        }
        return false;
    }
    public void EnemyCreate()
    {
        GameObject obj = Instantiate(Enemys[0], transform);
        EnemySpools.Enqueue(obj);
    }
    public void Enemyreturn(GameObject obj)
    {
        if(obj.gameObject.name == "Enemy(Clone)")
        {
            EnemySpools.Enqueue(obj);
        }
        else if(obj.gameObject.name == "Enemy M(Clone)")
        {
            EnemyMpools.Enqueue(obj);
        }
        else if (obj.gameObject.name == "Enemy L(Clone)")
        {
            EnemyLpools.Enqueue(obj);
        }
        obj.SetActive(false);
        
    }

    public GameObject EnemyObject()
    {
        if (Instance.CheckEnemypoos())
        {
            for (int i = 0; i < 20; i++)
            {
                GameObject newobj = Instantiate(Enemys[0], transform);
                newobj.SetActive(false);
                EnemySpools.Enqueue(newobj);
            }
        }
        GameObject obj = EnemySpools.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public void EnemyMreturn(GameObject obj)
    {
        obj.SetActive(false);
        EnemyMpools.Enqueue(obj);

    }
    public GameObject EnemyMObject()
    {
        if(EnemyMpools.Count == 0)
        {
            for (int i = 0; i < 20; i++)
            {
                GameObject obj2 = Instantiate(Enemys[1], transform);
                obj2.SetActive(false);
                EnemyMpools.Enqueue(obj2);
            }
        }
        GameObject obj = EnemyMpools.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public void EnemyLreturn(GameObject obj)
    {
        obj.SetActive(false);
        EnemyLpools.Enqueue(obj);
    }
    public GameObject EnemyLObject()
    {
        if(EnemyLpools.Count == 0)
        {
            for (int i = 0; i < 20; i++)
            {
                GameObject obj = Instantiate(Enemys[2], transform);
                obj.SetActive(false);
                EnemyLpools.Enqueue(obj);
            }
        }
        GameObject newobj = EnemyLpools.Dequeue();
        newobj.SetActive(true);
        return newobj;
    }

}
