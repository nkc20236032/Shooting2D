using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject shotPre;
    public GameObject shotPoint;

    float speed = 5;            // 移動速度
    public float Speed
    {
        set
        {
            speed = value;
            speed = Mathf.Clamp(speed, 0, 20);
        }
        get { return speed; }
    }

    int shotLevel;
    public int ShotLevel
    {
        set
        {
            shotLevel = value;
            shotLevel = Mathf.Clamp(shotLevel, 0, 12);
        }
        get { return shotLevel; }
    }

    float delta = 0.5f;        // 時間経過
    float shotspan = 0.5f;         // ショット間隔
    public float ShotSpan
    {
        set
        {
            shotspan = value;
            shotspan = Mathf.Clamp(shotspan, 0.5f, 0.1f);
        }
        get { return shotspan; }
    }


    Vector3 dir = Vector3.zero;

    Animator anim;

    void Start()
    {
        // アニメーターコンポーネントの情報を保存
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        // 移動方向をセット
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        transform.position += dir.normalized * speed * Time.deltaTime;

        // 画面内移動制限
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;

        // アニメーション設定
        if (dir.y == 0)
        {
            anim.Play("Player");
        }
        else if (dir.y == 1)
        {
            anim.Play("PlayerL");
        }
        else if (dir.y == -1)
        {
            anim.Play("PlayerR");
        }

        // 弾の発射
        delta += Time.deltaTime;
        if (Input.GetKey(KeyCode.Z) && delta >= shotspan)
        {
            for(int i = -shotLevel; i < shotLevel + 1; i++)
            {
                Vector3 p = transform.position;

                Quaternion rot = Quaternion.identity;
                rot.eulerAngles = transform.rotation.eulerAngles + new Vector3(0, 0, 15f * i);

                Instantiate(shotPre, p, rot);
            }


            delta = 0;
        }

    }

}
