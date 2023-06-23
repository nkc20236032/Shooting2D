using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero; // 移動方向
    float speed = 5f;            // 移動速度

    int enemyType;

    float delta = 0f;               // 経過時間
    float span = 2f;              // 発射間隔
    public GameObject enemyShotPre; // 発射するオブジェクト

    public GameObject explo;

    void Start()
    {
        enemyType = Random.Range(0, 3);
    }

    
    void Update()
    {
        // 移動方向を決定
        dir = Vector3.left;

        if (enemyType == 0)
        {
            dir.y = Mathf.Sin(Time.time * 5f);
        }

        // 現在地に移動量を加算
        transform.position += dir.normalized * speed * Time.deltaTime;

        // 弾の発射
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
