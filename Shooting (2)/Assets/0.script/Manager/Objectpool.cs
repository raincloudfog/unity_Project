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
    [SerializeField] GameObject[] items;
    

    Queue<GameObject> pools = new Queue<GameObject>();
    Queue<GameObject> Enemybulletpools = new Queue<GameObject>();
    Queue<GameObject> EnemySpools = new Queue<GameObject>();
    Queue<GameObject> EnemyMpools = new Queue<GameObject>();
    Queue<GameObject> EnemyLpools = new Queue<GameObject>();
    Queue<Coin> Coinpools = new Queue<Coin>();
    Queue<Power> Powerpools = new Queue<Power>();
    Queue<Boom> Boompools = new Queue<Boom>();

    public void Coinreturn(Coin obj)
    {
        Coinpools.Enqueue(obj);
        obj.gameObject.SetActive(false);

    }
    public Coin CoinCreate()
    {
        if(Coinpools.Count <= 0 )
        {
            for (int i = 0; i < 20; i++)
            {
                GameObject newobj = items[0];                
                Coinpools.Enqueue(newobj.GetComponent<Coin>());
                newobj.SetActive(false);
            }
        }
        Coin obj = Coinpools.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    //어웨이크
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    //체크풀
    public bool CheckPool()
    {
        if(pools.Count == 0)
        {
            return true;
        }
        return false;
    }
    //총알 생성
    public void Create()
    {
        GameObject obj = Instantiate(bullet[0], PlayerFirepos.transform);

        pools.Enqueue(obj);
    }
    //총알 반환
    public void ReturnObject(GameObject obj)
    {
        pools.Enqueue(obj);
        
        
    }
    //총알 쏘기
    public void playObject()
    {
        GameObject obj = pools.Dequeue();
        obj.SetActive(true);
        obj.transform.SetParent(null);
    }
    //적 총알 체크
    public bool CheckEnmeybulletPool()
    {
        if (Enemybulletpools.Count == 0)
        {
            return true;
        }
        return false;

    }
    //적 총알 생성
    public void EnmeybulleCreate()
    {
        GameObject obj = Instantiate(Enemybullet[0], transform);

        Enemybulletpools.Enqueue(obj);
    }
    //적총알 반환 및 끄기
    public void EnmeybulleReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        Enemybulletpools.Enqueue(obj);


    }
    //적 총알 쏘기 및 소환
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
    //작은 적 체크
    public bool CheckEnemypoos()
    {
        if(EnemySpools.Count == 0)
        {
            return true;
        }
        return false;
    }
    //작은적 생성
    public void EnemyCreate()
    {
        GameObject obj = Instantiate(Enemys[0], transform);
        EnemySpools.Enqueue(obj);
    }
    //작은적 반환및 끄기
    public void EnemySreturn(GameObject obj)
    {
        EnemySpools.Enqueue(obj);
        obj.SetActive(false);


    }
    //작은적 소환
    
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
    //중간적 반환
    public void EnemyMreturn(GameObject obj)
    {
        EnemyMpools.Enqueue(obj);
        obj.SetActive(false);
    }
    //중간 적 생성 및 끄기 및 소환

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
    //대형적 반환
    public void EnemyLreturn(GameObject obj)
    {
        obj.SetActive(false);
        EnemyLpools.Enqueue(obj);
    }
    //대형적 체크및 생성 및 소환
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
    //적 벽에 닿이면 반환
    public void Enemyreturn(GameObject obj)
    {
        if (obj.GetComponent<EnemyS>())
        {
            Instance.EnemySreturn(obj);
        }
        else if (obj.GetComponent<EnemyM>())
        {
            Instance.EnemyMreturn(obj);
        }
        else if (obj.GetComponent<EnemyL>())
        {
            Instance.EnemyLreturn(obj);
        }
    }

    

}
