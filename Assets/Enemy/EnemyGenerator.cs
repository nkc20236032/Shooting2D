using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPre; // �G�̃v���n�u��t������ϐ�
    public GameObject enemyPre2; 
    int type;
    float delta;                // �o�ߎ��Ԍv�Z�p
    float span;
    
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
            type = Random.Range(0, 2);
            // �G�𐶐�����
            if (type == 0)
            {
                GameObject go = Instantiate(enemyPre);
                float py = Random.Range(-5.8f, 6f);
                go.transform.position = new Vector3(10, py, 0);

            }
            else if (type == 1)
            {
                GameObject go = Instantiate(enemyPre2);
                float py = Random.Range(-5.8f, 6f);
                go.transform.position = new Vector3(10, py, 0);

            }
            // ���Ԍo�߂�ۑ����Ă���ϐ����O�N���A����
            delta = 0;

            // �G���o���Ԋu�����X�ɒZ������
            span -= (span >= 0.5f) ? 0.01f : 0f;
        }
    }
}
