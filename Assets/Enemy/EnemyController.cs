using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject enemySE;

    Vector3 dir = Vector3.zero; // �ړ�����
    float speed = 5f;            // �ړ����x
    int enemyHP;            // enemy��HP

    SpriteRenderer spriteRenderer;
    Color hitColor;
    string colorCord= "#FF6969";    // ��e�������̐F

    int enemyType;
    float rad;                  // �G�̓����T�C���J�[�u�p

    float delta = 0f;               // �o�ߎ���
    float span = 2f;              // ���ˊԊu
    public GameObject enemyShotPre; // ���˂���I�u�W�F�N�g

    public GameObject explo;

    PlayerController playerController;

    void Start()
    {
        rad = Time.time;                // �T�C���J�[�u�̓��������炷�p
        enemyType = Random.Range(0, 3); // enemy�̓������������_���Őݒ�
        enemyHP= Random.Range(10, 21);  // enemy��HP��ݒ�

        spriteRenderer = GetComponent<SpriteRenderer>();
        ColorUtility.TryParseHtmlString(colorCord, out hitColor);

        enemySE = GameObject.Find("GameAudioController");

        playerController= GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        // �ړ�����������
        dir = Vector3.left;

        if (enemyType == 0)
        {
            dir.y = Mathf.Sin(rad+Time.time * 5f);
        }

        // ���ݒn�Ɉړ��ʂ����Z
        transform.position += dir.normalized * speed * Time.deltaTime;
        // ��ʓ��ړ�����
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;


        // �e�̔���
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

        // HP��0�ɂȂ��������
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

            // �R���[�`���̋N��
            StartCoroutine(DelayCoroutine());
        }
    }
    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

}
