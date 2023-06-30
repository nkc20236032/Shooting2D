using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController2 : MonoBehaviour
{
    // アニメーションの最後に呼び出すメソッド
    // 爆発のアニメーションクリップにイベントとして登録
    public void ExepDelete2()
    {
        // 自分（爆発）削除
        Destroy(gameObject);
    }
}
