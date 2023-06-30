using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverDirector : MonoBehaviour
{
    AudioClip seClip;
    Vector3 sePos;

    void Start()
    {
        sePos = GameObject.Find("Main Camera").transform.position;
        seClip = Resources.Load<AudioClip>("Audio/SE/É`Å[Éì1");
        AudioSource.PlayClipAtPoint(seClip, sePos);
    }


    void Update()
    {
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            SceneManager.LoadScene("TitleScene");
        }

    }
}
