using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPre; // “G‚ÌƒvƒŒƒnƒu‚ð—t‘¹‚·‚é•Ï”
    public GameObject bossPre;
    float delta;                // Œo‰ßŽžŠÔŒvŽZ—p
    float span;

    int bossSwicth = 0;

    void Start()
    {
        delta = 0;
        span = 1;
    }

    
    void Update()
    {
        // Œo‰ßŽžŠÔ‚ð‰ÁŽZ
        delta += Time.deltaTime;

        if (delta > span)
        {
            // “G‚ð¶¬‚·‚é
            
                GameObject go = Instantiate(enemyPre);
                float py = Random.Range(-5.8f, 6f);
                go.transform.position = new Vector3(10, py, 0);

            // ŽžŠÔŒo‰ß‚ð•Û‘¶‚µ‚Ä‚¢‚é•Ï”‚ð‚OƒNƒŠƒA‚·‚é
            delta = 0;

            // “G‚ðo‚·ŠÔŠu‚ð™X‚É’Z‚­‚·‚é
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
