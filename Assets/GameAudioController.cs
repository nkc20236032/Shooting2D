using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioController : MonoBehaviour
{
    AudioSource audioSource;

    AudioClip bgmClip;
    AudioClip[] seClip=new AudioClip[6];
    Vector3 sePos;

    void Start()
    {
        bgmClip = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit11");

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgmClip;
        audioSource.Play();

        string[] seName =
        {
            "Audio/SE/damage1",
            "Audio/SE/bomb",
            "Audio/SE/shoot3",
            "Audio/SE/shoot2",
            "Audio/SE/ゲージ回復2",
            "Audio/SE/小パンチ",
            "Audio/SE/"
        };
        for(int i = 0; i < seName.Length; i++)
        {
            seClip[i] = Resources.Load<AudioClip>(seName[i]);
        }
        sePos = GameObject.Find("Main Camera").transform.position;
    }


    void Update()
    {
        
    }

    public void EnemyHitSE()
    {
        AudioSource.PlayClipAtPoint(seClip[0], sePos);
    }
    public void EnemyDestroySE()
    {
        AudioSource.PlayClipAtPoint(seClip[1], sePos);
    }
    public void EnemyShotSE()
    {
        AudioSource.PlayClipAtPoint(seClip[2], sePos);
    }

    public void PlayerShotSE()
    {
        AudioSource.PlayClipAtPoint(seClip[3], sePos);
    }
    public void ItemGetSE()
    {
        AudioSource.PlayClipAtPoint(seClip[4], sePos);
    }
    public void HidanSE()
    {
        AudioSource.PlayClipAtPoint(seClip[5], sePos);
    }
    public void BossDestroySE()
    {
        AudioSource.PlayClipAtPoint(seClip[6], sePos);
    }

}
