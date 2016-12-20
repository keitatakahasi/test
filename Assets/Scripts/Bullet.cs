using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    void Start ()
    {
        // シーンに配置されているゲームオブジェクト「Player」のtoransformを取得
        Transform playerTransform = GameObject.Find("Player").transform;

        // 弾の発射位置をプレーヤーの場所へ
        transform.position = playerTransform.position;

        // 弾の向きをプレーヤーの向きに合わせる
        transform.forward = playerTransform.forward;
    }

    void Update ()
    {
        float speed = 10.0f; // 弾の移動速度

        // 弾（プレーヤー）が向いている方向に移動
        transform.position += transform.forward * speed * Time.deltaTime;

        // 原点からの距離が30.0fより大きい時（超アバウト判定）
        if(transform.position.magnitude > 50.0f*1.41f )
        {
            Destroy(gameObject);    // 自分自身を削除
        }

    }
}
