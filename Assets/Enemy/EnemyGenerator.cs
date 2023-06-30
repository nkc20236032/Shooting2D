using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPre; // �G�̃v���n�u��t������ϐ�
    public GameObject bossPre;
    float delta;                // �o�ߎ��Ԍv�Z�p
    float span;

    int bossSwicth = 0;

    void Start()
    {
        delta = 0;
        span = 1;
    }

    
    void Update()
    {
        // �o�ߎ��Ԃ����Z
        delta += Time.deltaTime;

        if (delta > span)
        {
            // �G�𐶐�����
            
                GameObject go = Instantiate(enemyPre);
                float py = Random.Range(-5.8f, 6f);
                go.transform.position = new Vector3(10, py, 0);

            // ���Ԍo�߂�ۑ����Ă���ϐ����O�N���A����
            delta = 0;

            // �G���o���Ԋu�����X�ɒZ������
            span -= (span >= 0.5f) ? 0.012f : 0f;
        }
        if ((GameDirector.lastTime <= 60 && bossSwicth == 0) || (GameDirector.lastTime <= 30 && bossSwicth == 1))
        {
            GameObject go = Instantiate(bossPre);
            go.transform.position = new Vector3(10, 0, 0);
            bossSwicth++;
        }
    }
}
