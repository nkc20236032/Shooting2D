using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerRen : MonoBehaviour
{
    Transform player;
    
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    
    void Update()
    {
        float speed = 5f;
        Vector3 dir = Vector3.left;

        //if (transform.position.x < -9)
        //{
        //    Vector3 pos = transform.position;
        //    pos.x = 9f;
        //    transform.position = pos;
        //}

        //// Y•ûŒü‚ÌˆÚ“®
        //dir.y = Mathf.Sin(Time.time * 5f);

        dir = player.position - transform.position;

        transform.position += dir.normalized * speed * Time.deltaTime;
    }
}
