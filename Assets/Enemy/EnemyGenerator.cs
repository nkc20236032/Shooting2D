using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPre; // “G‚ÌƒvƒŒƒnƒu‚ð—t‘¹‚·‚é•Ï”
    public GameObject enemyPre2; 
    int type;
    float delta;                // Œo‰ßŽžŠÔŒvŽZ—p
    float span;
    
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
            type = Random.Range(0, 2);
            // “G‚ð¶¬‚·‚é
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
            // ŽžŠÔŒo‰ß‚ð•Û‘¶‚µ‚Ä‚¢‚é•Ï”‚ð‚OƒNƒŠƒA‚·‚é
            delta = 0;

            // “G‚ðo‚·ŠÔŠu‚ð™X‚É’Z‚­‚·‚é
            span -= (span >= 0.5f) ? 0.01f : 0f;
        }
    }
}
