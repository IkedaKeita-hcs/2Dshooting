using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    //オブジェクトプール
    [SerializeField] ObjectPoolController objectPool;
    //発射の間隔
    [SerializeField] float interval;

    void Start()
    {
        //発射用コルーチンスタート
        StartCoroutine(Shot());
    }

    //コルーチン
    IEnumerator Shot()
    {
        //発射ループ
        while (true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                //オブジェクトプールのLaunch関数呼び出し
                objectPool.Launch(transform.position);
            }
            
            yield return new WaitForSeconds(interval);
        }

    }
}
