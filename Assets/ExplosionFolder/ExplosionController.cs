using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    // アニメーションの最後に呼び出すメソッド
    // 爆発のアニメーションクリップにイベントとして登録
    public void ExepDelete()
    {
        // 自分（爆発）削除
        Destroy(gameObject);
    }
}
