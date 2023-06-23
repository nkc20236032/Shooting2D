using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject item;

    public static int DEnemy = 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (DEnemy == 7)
        {
                GameObject go = Instantiate(item);
                float px = Random.Range(-8f, 8f);
                go.transform.position = new Vector3(px, 5.5f, 0);
            DEnemy = 0;
        }
    }
}
