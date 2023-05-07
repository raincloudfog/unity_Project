using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Collider2D player;

    void Update()
    {
        player = Physics2D.OverlapCircle(transform.position, this.GetComponent<BoxCollider2D>().size.y);
        transform.position = transform.position + Vector3.down * Time.deltaTime * 3f;
    }
}
