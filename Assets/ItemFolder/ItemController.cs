using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    SpriteRenderer spRender;    // レンダラーコンポーネント取得

    float speed = 4.0f;
    Vector3 dir = Vector3.down;

    int itemType;

    GameObject itemGetSE;
    
    void Start()
    {
                        // 0:赤、1:緑、2:青
        Color[] col = { Color.red, Color.green, Color.yellow, Color.blue };
        itemType = Random.Range(0, col.Length);
        spRender = GetComponent<SpriteRenderer>();
        spRender.color = col[itemType];

        itemGetSE = GameObject.Find("GameAudioController");
    }


    void Update()
    {
        transform.position += dir.normalized * speed * Time.deltaTime;

        if (transform.position.y < -5.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            // PlayerControllerコンポーネントを保存
            PlayerController pCon = col.gameObject.GetComponent<PlayerController>();
            if(itemType == 0)
            {
                pCon.ShotLevel += 1;
            }
            else if (itemType == 1)
            {
                pCon.Speed += 2;
            }
            else if (itemType == 2)
            {
                pCon.ShotSpan -= 0.02f;
            }
            else if(itemType == 3)
            {
                pCon.ShotLevel -= 1;
                pCon.Speed -= 2;
                pCon.ShotSpan += 0.02f;
                pCon.PlayerHP += 10;
            }
            itemGetSE.GetComponent<GameAudioController>().ItemGetSE();

            Destroy(gameObject);
        }
    }
}
