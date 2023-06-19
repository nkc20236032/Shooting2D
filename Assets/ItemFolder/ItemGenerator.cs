using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject itemR;
    public GameObject itemG;
    public GameObject itemB;

    public static int DEnemy = 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (DEnemy == 8)
        {
            int type = Random.Range(0, 3);
            if (type == 0)
            {
                GameObject go = Instantiate(itemR);
                float px = Random.Range(-8f, 8f);
                go.transform.position = new Vector3(px, 5.5f, 0);
            }
            else if (type == 1)
            {
                GameObject go = Instantiate(itemG);
                float px = Random.Range(-8f, 8f);
                go.transform.position = new Vector3(px, 5.5f, 0);
            }
            else
            {
                GameObject go = Instantiate(itemB);
                float px = Random.Range(-8f, 8f);
                go.transform.position = new Vector3(px, 5.5f, 0);
            }
            DEnemy = 0;
        }
    }
}
