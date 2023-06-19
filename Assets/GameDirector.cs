using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel;
    public static int kyori;

    public Image timeGauge;     // タイムゲージを表示するUI

    public static float lastTime;             // 残り時間を保存する変数
    
    void Start()
    {
        kyori = 0;
        lastTime = 100f;
    }

    
    void Update()
    {
        // 残し時間を減らす処理
        lastTime -= Time.deltaTime;
        timeGauge.fillAmount = lastTime / 100;

        if (lastTime < 0)
        {
            SceneManager.LoadScene("TitleScene");
        }

        kyori = (kyori < 0) ? 0 : kyori;
        kyori++;
        kyoriLabel.text = kyori.ToString("D6") + "km";
    }
}
