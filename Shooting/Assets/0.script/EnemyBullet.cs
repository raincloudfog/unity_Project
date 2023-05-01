using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bulletLife());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator bulletLife()
    {
        yield return new WaitForSeconds(2f);
        Objectpool.Instance.EnmeybulleReturnObject(gameObject);

    }
}
