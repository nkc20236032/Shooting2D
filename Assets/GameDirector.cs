using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel;
    public static int kyori;

    public Image timeGauge;     // �^�C���Q�[�W��\������UI

    public static float lastTime;             // �c�莞�Ԃ�ۑ�����ϐ�
    
    void Start()
    {
        kyori = 0;
        lastTime = 100f;
    }

    
    void Update()
    {
        // �c�����Ԃ����炷����
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
