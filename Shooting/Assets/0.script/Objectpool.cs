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
    Queue<GameObject> Enemypools = new Queue<GameObject>();


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
}
