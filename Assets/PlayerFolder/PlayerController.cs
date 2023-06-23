using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject shotPre;
    public GameObject shotPoint;

    float speed = 5;            // �ړ����x
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

    float delta = 0.5f;        // ���Ԍo��
    float shotspan = 0.5f;         // �V���b�g�Ԋu
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
        // �A�j���[�^�[�R���|�[�l���g�̏���ۑ�
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        // �ړ��������Z�b�g
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        transform.position += dir.normalized * speed * Time.deltaTime;

        // ��ʓ��ړ�����
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;

        // �A�j���[�V�����ݒ�
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

        // �e�̔���
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
