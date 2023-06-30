using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossController : MonoBehaviour
{
    GameObject enemySE;

    Vector3 dir = Vector3.zero; // �ړ�����
    float speed = 3.5f;            // �ړ����x
    int enemyHP;            // enemy��HP

    int tarn = 0;

    SpriteRenderer spriteRenderer;
    Color hitColor;
    string colorCord = "#FF6969";    // ��e�������̐F

    float delta = 0f;               // �o�ߎ���
    float span = 2f;              // ���ˊԊu
    public GameObject enemyShotPre; // ���˂���I�u�W�F�N�g

    public GameObject explo;

    PlayerController playerController;

    void Start()
    {

        enemyHP = 500;  // enemy��HP��ݒ�

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

            // ��ʓ��ړ�����
            Vector3 pos = transform.position;
            pos.y = Mathf.Clamp(pos.y, -4.5f, 4.5f);
            transform.position = pos;


            // �e�̔���
            delta += Time.deltaTime;
            if (delta > span)
            {
                StartCoroutine(DelayShot());

                delta = 0f;
            }
        }




        // HP��0�ɂȂ��������
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

            // �R���[�`���̋N��
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
