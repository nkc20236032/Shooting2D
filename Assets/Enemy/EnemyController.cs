using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero; // �ړ�����
    float speed = 5f;            // �ړ����x

    float delta = 0f;               // �o�ߎ���
    float span = 2f;              // ���ˊԊu
    public GameObject enemyShotPre; // ���˂���I�u�W�F�N�g

    void Start()
    {
        // ����4�b
        Destroy(gameObject, 4f);
    }

    
    void Update()
    {
        // �ړ�����������
        dir = Vector3.left;

        // ���ݒn�Ɉړ��ʂ����Z
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
        if(collision.gameObject.tag== "Player")
        {
            GameDirector.kyori -= 1000;
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Shot")
        {
            GameDirector.kyori += 200;
            Destroy(collision.gameObject);
            Destroy(gameObject);

            ItemGenerator.DEnemy += 1;
        }
    }
}
