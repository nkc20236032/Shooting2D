using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    float delta = 0f;               // 経過時間
    float span = 2f;              // 発射間隔
    public GameObject enemyShotPre; // 発射するオブジェクト

    void Start()
    {
        // 寿命5秒
        Destroy(gameObject, 5f);
    }


    void Update()
    {
        float speed = 5f;               // 移動速度
        Vector3 dir = Vector3.left;

        // Y方向の移動
        dir.y = Mathf.Sin(Time.time * 5f);

        transform.position += dir.normalized * speed * Time.deltaTime;

        // 弾の発射
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
