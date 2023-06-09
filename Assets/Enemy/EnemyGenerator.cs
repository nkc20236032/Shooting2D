using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPre; // 敵のプレハブを葉損する変数
    public GameObject bossPre;
    float delta;                // 経過時間計算用
    float span;

    int bossSwicth = 0;

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
            // 敵を生成する
            
                GameObject go = Instantiate(enemyPre);
                float py = Random.Range(-5.8f, 6f);
                go.transform.position = new Vector3(10, py, 0);

            // 時間経過を保存している変数を０クリアする
            delta = 0;

            // 敵を出す間隔を徐々に短くする
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
