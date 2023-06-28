using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero; // �ړ�����
    float speed = 5f;            // �ړ����x
    int enemyHP;

    SpriteRenderer spriteRenderer;
    Color hitColor;
    string colorCord= "#FF6969";

    int enemyType;

    float delta = 0f;               // �o�ߎ���
    float span = 2f;              // ���ˊԊu
    public GameObject enemyShotPre; // ���˂���I�u�W�F�N�g

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
