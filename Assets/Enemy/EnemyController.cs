using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero; // 移動方向
    float speed = 5f;            // 移動速度
    int enemyHP;

    SpriteRenderer spriteRenderer;
    Color hitColor;
    string colorCord= "#FF6969";

    int enemyType;

    float delta = 0f;               // 経過時間
    float span = 2f;              // 発射間隔
    public GameObject enemyShotPre; // 発射するオブジェクト

    public GameObject explo;

    void Start()
    {
        enemyType = Random.Range(0, 3);
        enemyHP= Random.Range(10, 21);

        spriteRenderer = GetComponent<SpriteRenderer>();
        ColorUtility.TryParseHtmlString(colorCord, out hitColor);
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

        if (enemyHP <= 0)
        {
            GameDirector.kyori += 200;

            Instantiate(explo, transform.position, Quaternion.identity);

            ItemGenerator.DEnemy += 1;
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
            MyShotController msCon=collision.gameObject.GetComponent<MyShotController>();
            spriteRenderer.color = hitColor;


            Destroy(collision.gameObject);
            enemyHP -= msCon.ShotPower;

            // コルーチンの起動
            StartCoroutine(DelayCoroutine());
        }
    }
    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

}
