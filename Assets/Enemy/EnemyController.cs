using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject enemySE;

    Vector3 dir = Vector3.zero; // 移動方向
    float speed = 5f;            // 移動速度
    int enemyHP;            // enemyのHP

    SpriteRenderer spriteRenderer;
    Color hitColor;
    string colorCord= "#FF6969";    // 被弾した時の色

    int enemyType;
    float rad;                  // 敵の動きサインカーブ用

    float delta = 0f;               // 経過時間
    float span = 2f;              // 発射間隔
    public GameObject enemyShotPre; // 発射するオブジェクト

    public GameObject explo;

    PlayerController playerController;

    void Start()
    {
        rad = Time.time;                // サインカーブの動きをずらす用
        enemyType = Random.Range(0, 3); // enemyの動き方をランダムで設定
        enemyHP= Random.Range(10, 21);  // enemyのHPを設定

        spriteRenderer = GetComponent<SpriteRenderer>();
        ColorUtility.TryParseHtmlString(colorCord, out hitColor);

        enemySE = GameObject.Find("GameAudioController");

        playerController= GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        // 移動方向を決定
        dir = Vector3.left;

        if (enemyType == 0)
        {
            dir.y = Mathf.Sin(rad+Time.time * 5f);
        }

        // 現在地に移動量を加算
        transform.position += dir.normalized * speed * Time.deltaTime;
        // 画面内移動制限
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;


        // 弾の発射
        delta += Time.deltaTime;
        if (delta > span)
        {
            enemySE.GetComponent<GameAudioController>().EnemyShotSE();
            Instantiate(enemyShotPre, transform.position, Quaternion.identity);
            delta = 0f;
        }

        if (transform.position.x < -10.0f)
        {
            Destroy(gameObject);
        }

        // HPが0になったら消滅
        if (enemyHP <= 0)
        {
            GameDirector.kyori += 200;

            Instantiate(explo, transform.position, Quaternion.identity);
            enemySE.GetComponent<GameAudioController>().EnemyDestroySE();

            ItemGenerator.DEnemy += 1;
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "Player")
        {
            GameDirector.kyori -= 1000;
            playerController.PlayerHP -= 10;
            Instantiate(explo, transform.position, Quaternion.identity);
            enemySE.GetComponent<GameAudioController>().HidanSE();
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Shot")
        {
            MyShotController msCon=collision.gameObject.GetComponent<MyShotController>();
            spriteRenderer.color = hitColor;


            Destroy(collision.gameObject);
            enemyHP -= msCon.ShotPower;
            enemySE.GetComponent<GameAudioController>().EnemyHitSE();

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
