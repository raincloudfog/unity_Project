using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(bulletlifespan());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * 3f * Time.deltaTime;



    }
    
    IEnumerator bulletlifespan()
    {
        yield return new WaitForSeconds(2f);
        Objectpool.Instance.ReturnObject(gameObject);
        transform.SetParent(Objectpool.Instance.PlayerFirepos.transform);
        transform.position = Objectpool.Instance.PlayerFirepos.transform.position;
        gameObject.SetActive(false);
    }
}
