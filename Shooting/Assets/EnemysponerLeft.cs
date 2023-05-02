using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysponerLeft : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spon());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spon()
    {
        int i = 0;
        int j = 1;
        yield return new WaitForSeconds(1f);
        while (i < 5)
        {
            yield return new WaitForSeconds(1f);
            GameObject obj = Objectpool.Instance.EnemyObject();
            
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.Euler(0, 0, 45);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(1, -Mathf.Deg2Rad * 45) * obj.GetComponent<EnemyS>().Speed;
            
            
            i++;
        }
        
        
    }
}
