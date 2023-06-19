using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    float speed = 4.0f;
    Vector3 dir = Vector3.down;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position += dir.normalized * speed * Time.deltaTime;

        if (transform.position.y < -5.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
