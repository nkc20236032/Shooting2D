using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleAudioController : MonoBehaviour
{
    AudioSource audioSource;

    AudioClip bgmClip;
    AudioClip seClip;
    Vector3 sePos;

    void Start()
    {
        bgmClip = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit08");

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgmClip;
        audioSource.Play();

        sePos = GameObject.Find("Main Camera").transform.position;
        seClip = Resources.Load<AudioClip>("Audio/SE/pa1");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AudioSource.PlayClipAtPoint(seClip, sePos);
        }

    }

}
