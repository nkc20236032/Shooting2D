using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{

    
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            StartCoroutine(DelayCoroutine());
        }
    }
    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("GameScene");
    }

}
