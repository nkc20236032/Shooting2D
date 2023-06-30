using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClearDirector : MonoBehaviour
{
    AudioClip seClip;
    Vector3 sePos;

    public Text score;


    void Start()
    {
        sePos = GameObject.Find("Main Camera").transform.position;
        seClip = Resources.Load<AudioClip>("Audio/SE/レベルアップ");
        AudioSource.PlayClipAtPoint(seClip, sePos);

        score.text = "Score\n" + GameDirector.kyori.ToString("D6");

    }


    void Update()
    {
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            SceneManager.LoadScene("TitleScene");
        }

    }
}
