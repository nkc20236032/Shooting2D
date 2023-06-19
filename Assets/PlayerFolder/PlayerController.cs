using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject shotPre;
    public GameObject shotPoint;

    float speed = 6;            // �ړ����x
    float delta = 0.4f;        // ���Ԍo��
    float shotspan = 0.4f;         // �V���b�g�Ԋu

    int itemR = 0;      // ItemR�̎擾���𐔂���

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
            Instantiate(shotPre, shotPoint.transform.position, transform.rotation);

            if (itemR >= 1)
            {
                Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, -75));
                Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, -105));
            }
            if (itemR >= 2)
            {
                Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, -60));
                Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, -120));
            }
            if (itemR >= 3)
            {
                Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, -30));
                Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, -150));
                Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, -180));
                Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, 30));
                Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, 150));
                Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, 60));
                Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, 120));
                Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, 90));
            }
            //if (itemR >= 4)
            //{
            //    Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, 15));
            //    Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, 165));
            //    Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, 45));
            //    Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, 135));
            //    Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, 75));
            //    Instantiate(shotPre, shotPoint.transform.position, Quaternion.Euler(0, 0, 105));
            //}
            delta = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ItemR")
        {
            itemR += 1;
        }

        if (col.gameObject.tag == "ItemG")
        {
            speed += 2;
        }

        if (col.gameObject.tag == "ItemB")
        {
            itemR = 0;
            speed = 5;
        }

    }
}
