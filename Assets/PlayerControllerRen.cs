using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRen : MonoBehaviour
{
    public GameObject shotPre;
    public GameObject shotPoint;
    float delta = 0.5f;        // ���Ԍo��
    float shotspan = 0.5f;         // �V���b�g�Ԋu


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
