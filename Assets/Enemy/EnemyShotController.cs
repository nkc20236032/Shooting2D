using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController : MonoBehaviour
{
    GameObject enemyShotSE;

    Transform player;
    Vector3 dir = Vector3.zero;

    PlayerController playerController;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        dir = player.position - transform.position;

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        enemyShotSE = GameObject.Find("GameAudioController");
    }


    void Update()
    {
        float speed = 6f;

        transform.position += dir.normalized * speed * Time.deltaTime;

        if (transform.position.x >= 9.0f || transform.position.x <= -9.0f ||
        transform.position.y >= 5.5f || transform.position.y <= -5.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyShotSE.GetComponent<GameAudioController>().HidanSE();
            GameDirector.kyori -= 500;
            playerController.PlayerHP -= 2;
            Destroy(gameObject);
        }
    }

}
