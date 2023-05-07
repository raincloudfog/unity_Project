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

    //�����ũ
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    //üũǮ
    public bool CheckPool()
    {
        if(pools.Count == 0)
        {
            return true;
        }
        return false;
    }
    //�Ѿ� ����
    public void Create()
    {
        GameObject obj = Instantiate(bullet[0], PlayerFirepos.transform);

        pools.Enqueue(obj);
    }
    //�Ѿ� ��ȯ
    public void ReturnObject(GameObject obj)
    {
        pools.Enqueue(obj);
        
        
    }
    //�Ѿ� ���
    public void playObject()
    {
        GameObject obj = pools.Dequeue();
        obj.SetActive(true);
        obj.transform.SetParent(null);
    }
    //�� �Ѿ� üũ
    public bool CheckEnmeybulletPool()
    {
        if (Enemybulletpools.Count == 0)
        {
            return true;
        }
        return false;

    }
    //�� �Ѿ� ����
    public void EnmeybulleCreate()
    {
        GameObject obj = Instantiate(Enemybullet[0], transform);

        Enemybulletpools.Enqueue(obj);
    }
    //���Ѿ� ��ȯ �� ����
    public void EnmeybulleReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        Enemybulletpools.Enqueue(obj);


    }
    //�� �Ѿ� ��� �� ��ȯ
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
    //���� �� üũ
    public bool CheckEnemypoos()
    {
        if(EnemySpools.Count == 0)
        {
            return true;
        }
        return false;
    }
    //������ ����
    public void EnemyCreate()
    {
        GameObject obj = Instantiate(Enemys[0], transform);
        EnemySpools.Enqueue(obj);
    }
    //������ ��ȯ�� ����
    public void EnemySreturn(GameObject obj)
    {
        EnemySpools.Enqueue(obj);
        obj.SetActive(false);


    }
    //������ ��ȯ
    
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
    //�߰��� ��ȯ
    public void EnemyMreturn(GameObject obj)
    {
        EnemyMpools.Enqueue(obj);
        obj.SetActive(false);
    }
    //�߰� �� ���� �� ���� �� ��ȯ

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
    //������ ��ȯ
    public void EnemyLreturn(GameObject obj)
    {
        obj.SetActive(false);
        EnemyLpools.Enqueue(obj);
    }
    //������ üũ�� ���� �� ��ȯ
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
    //�� ���� ���̸� ��ȯ
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
