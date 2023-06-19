using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRen : MonoBehaviour
{
    public GameObject shotPre;
    public GameObject shotPoint;
    float delta = 0.5f;        // 時間経過
    float shotspan = 0.5f;         // ショット間隔


    Vector3 dir = Vector3.zero;

    void Start()
    {
        
    }

    
    void Update()
    {
        float speed = 5;

        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        transform.position += dir.normalized * speed * Time.deltaTime;

        delta += Time.deltaTime;
        if (Input.GetAxisRaw("Fire1") == 1 && delta >= shotspan)
        {
            GameObject go = Instantiate(shotPre);
            go.transform.position = shotPoint.transform.position;
        }
    }
}
