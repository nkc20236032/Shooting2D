using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    float delta = 0f;               // �o�ߎ���
    float span = 2f;              // ���ˊԊu
    public GameObject enemyShotPre; // ���˂���I�u�W�F�N�g

    void Start()
    {
        // ����5�b
        Destroy(gameObject, 5f);
    }


    void Update()
    {
        float speed = 5f;               // �ړ����x
        Vector3 dir = Vector3.left;

        // Y�����̈ړ�
        dir.y = Mathf.Sin(Time.time * 5f);

        transform.position += dir.normalized * speed * Time.deltaTime;

        // �e�̔���
        delta += Time.deltaTime;
        if (delta > span)
        {
            Instantiate(enemyShotPre, transform.position, Quaternion.identity);
            delta = 0f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameDirector.kyori -= 1000;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Shot")
        {
            GameDirector.kyori += 200;
            Destroy(collision.gameObject);
            Destroy(gameObject);

            ItemGenerator.DEnemy += 1;
        }
    }

}
