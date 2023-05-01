using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemysponer : MonoBehaviour
{
    [SerializeField] GameObject[] Enemys;

    int i = 0;
    int j = 0;
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
        yield return new WaitForSeconds(2f);
        while (i < 5)
        {
            yield return new WaitForSeconds(0.4f);
            GameObject obj = Instantiate(Enemys[0], transform);
            obj.transform.position = new Vector3(2, 0, 0) + transform.position;
            obj.transform.position += Vector3.down * Time.deltaTime * 3f;
            i++;
        }
        
        
        yield return new WaitForSeconds(2f);
        while(j < 5)
        {
            yield return new WaitForSeconds(0.4f);
            GameObject obj = Instantiate(Enemys[0], transform);
            obj.transform.position = new Vector3(-2, 0, 0) + transform.position;
            obj.transform.position += Vector3.down * Time.deltaTime * 3f;
            
            j++;
        }
        
    }
}
