using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysponerRight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(new Vector2(Mathf.Deg2Rad * -30, Mathf.Deg2Rad * -30));
        StartCoroutine(spon());
    }

    IEnumerator spon()
    {
        int i = 0;
        int j = 0;
        yield return new WaitForSeconds(1f);
        while(i < 2)
        {
            yield return new WaitForSeconds(1f);
            GameObject obj = Objectpool.Instance.EnemyMObject();
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.Euler(0, 0, -45);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Deg2Rad * -30, Mathf.Deg2Rad * -30) * obj.GetComponent<EnemyM>().Speed;
            i++;
        }
        
    }
}
