using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPre; // 敵のプレハブを葉損する変数
    public GameObject enemyPre2; 
    int type;
    float delta;                // 経過時間計算用
    float span;
    
    void Start()
    {
        delta = 0;
        span = 1;
    }

    
    void Update()
    {
        // 経過時間を加算
        delta += Time.deltaTime;

        if (delta > span)
        {
            type = Random.Range(0, 2);
            // 敵を生成する
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
            // 時間経過を保存している変数を０クリアする
            delta = 0;

            // 敵を出す間隔を徐々に短くする
            span -= (span >= 0.5f) ? 0.01f : 0f;
        }
    }
}
