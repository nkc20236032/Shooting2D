using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero; // �ړ�����
    float speed = 5f;            // �ړ����x

    int enemyType;

    float delta = 0f;               // �o�ߎ���
    float span = 2f;              // ���ˊԊu
    public GameObject enemyShotPre; // ���˂���I�u�W�F�N�g

    public GameObject explo;

    void Start()
    {
        enemyType = Random.Range(0, 3);
    }

    
    void Update()
    {
        // �ړ�����������
        dir = Vector3.left;

        if (enemyType == 0)
        {
            dir.y = Mathf.Sin(Time.time * 5f);
        }

        // ���ݒn�Ɉړ��ʂ����Z
        transform.position += dir.normalized * speed * Time.deltaTime;

        // �e�̔���
        delta += Time.deltaTime;
        if (delta > span)
        {
            Instantiate(enemyShotPre, transform.position, Quaternion.identity);
            delta = 0f;
        }

        if (transform.position.x < -10.0f)
        {
            Destroy(gameObject);
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

            Instantiate(explo, transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);

            ItemGenerator.DEnemy += 1;
        }
    }
}
