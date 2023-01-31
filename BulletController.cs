using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    ObjectPoolController objectPool;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトプールを取得
        objectPool = transform.parent.GetComponent<ObjectPoolController>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
      　//下の回収処理を呼び出す
        HideFromStage();
    }


    public void ShowInStage(Vector3 _pos)
    {
        //positionを渡された座標に設定
        transform.position = _pos;
    }

    public void HideFromStage()
    {
        //オブジェクトプールのCollect関数を呼び出し自身を回収
        objectPool.Collect(this);
    }
}
