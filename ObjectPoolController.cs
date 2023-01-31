using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolController : MonoBehaviour
{
    //弾のプレファブ
    [SerializeField] BulletController _bullet;
    //生成する数
    [SerializeField] int _maxCount;
    //生成した弾を格納するQueue
    Queue<BulletController> _bulletQueue;

    Vector3 setPos = new Vector3(100, 100, 0);

    private void Awake()
    {
        //Queueの初期化
        _bulletQueue = new Queue<BulletController>();

        //弾を生成するループ
        for (int i = 0; i < _maxCount; i++)
        {
            //生成
            BulletController tmpBullet = Instantiate(_bullet, setPos, Quaternion.identity, transform);
            //Queueに追加
            _bulletQueue.Enqueue(tmpBullet);
        }
    }

    public BulletController Launch(Vector3 _pos)
    {
        //Queueが空ならnull
        if (_bulletQueue.Count <= 0) return null;

        //Queueから弾を一つ取り出す
        BulletController tmpBullet = _bulletQueue.Dequeue();
        //弾を表示する
        tmpBullet.gameObject.SetActive(true);
        //渡された座標に弾を移動する
        tmpBullet.ShowInStage(_pos);
        //呼び出し元に渡す
        return tmpBullet;
    }
    // Update is called once per frame
    public void Collect(BulletController bullet)
    {
        //弾のゲームオブジェクトを非表示
        bullet.gameObject.SetActive(false);
        //Queueに格納
        _bulletQueue.Enqueue(bullet);
    }
}
