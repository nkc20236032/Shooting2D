using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShotController : MonoBehaviour
{
    float speed = 10f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        if (transform.position.x >= 9.0f || transform.position.x <= -9.0f ||
            transform.position.y >= 5.5f || transform.position.y <= -5.5f)
        {
            Destroy(gameObject);
        }
    }
}
