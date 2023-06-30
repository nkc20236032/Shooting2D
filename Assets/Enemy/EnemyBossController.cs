using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossController : MonoBehaviour
{
    GameObject enemySE;

    Vector3 dir = Vector3.zero; // 移動方向
    float speed = 3.5f;            // 移動速度
    int enemyHP;            // enemyのHP

    int tarn = 0;

    SpriteRenderer spriteRenderer;
    Color hitColor;
    string colorCord = "#FF6969";    // 被弾した時の色

    float delta = 0f;               // 経過時間
    float span = 2f;              // 発射間隔
    public GameObject enemyShotPre; // 発射するオブジェクト

    public GameObject explo;

    PlayerController playerController;

    void Start()
    {

        enemyHP = 500;  // enemyのHPを設定

        spriteRenderer = GetComponent<SpriteRenderer>();
        ColorUtility.TryParseHtmlString(colorCord, out hitColor);

        enemySE = GameObject.Find("GameAudioController");

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void Update()
    {
        if (transform.position.x <= 6.0f && tarn == 0)
        {
            tarn = 1;
        }

        if (tarn == 0)
        {
            dir = Vector3.left;
            transform.position += dir.normalized * speed * Time.deltaTime;
        }
        else
        {
            dir.x = 0f;
            dir.y = Mathf.Sin(Time.time * 1f);
            transform.position += dir.normalized * speed * Time.deltaTime;

            // 画面内移動制限
            Vector3 pos = transform.position;
            pos.y = Mathf.Clamp(pos.y, -4.5f, 4.5f);
            transform.position = pos;


            // 弾の発射
            delta += Time.deltaTime;
            if (delta > span)
            {
                StartCoroutine(DelayShot());

                delta = 0f;
            }
        }




        // HPが0になったら消滅
        if (enemyHP <= 0)
        {
            GameDirector.kyori += 1000;

            Instantiate(explo, transform.position, Quaternion.identity);
            enemySE.GetComponent<GameAudioController>().EnemyDestroySE();

            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameDirector.kyori -= 1000;
            playerController.PlayerHP -= 20;
            Instantiate(explo, transform.position, Quaternion.identity);
            enemySE.GetComponent<GameAudioController>().HidanSE();
        }

        if (collision.gameObject.tag == "Shot")
        {
            MyShotController msCon = collision.gameObject.GetComponent<MyShotController>();
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
        spriteRenderer.color = Color.magenta;
    }
    private IEnumerator DelayShot()
    {
        for(int i = 0; i < 10; i++)
        {
            enemySE.GetComponent<GameAudioController>().EnemyShotSE();
            Instantiate(enemyShotPre, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }

}
