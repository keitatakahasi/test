//-----------------------------------------------------------------------------
// ファイル名：Move.cs
// 内　容　　：オブジェクトを動かすスクリプト
// Copyright ：Ken.D.Ohishi 2016.06.10
//-----------------------------------------------------------------------------
using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    float speed     = 0.0f;    // 1フレームあたりの移動量( speed(速度) )
    float accel     = 0.01f;   // 1回あたりの加速度( accel : acceleration(加速度) )
    float addDegree = 5.0f;    // 1回あたりの回転角度 （ addDegree : add(加算)　degree(度) ）

    GameObject bullet;           // 弾の情報を保存するゲームオブジェクト
    private float time;                 // 経過時間
    public float timeInterval;          // 間隔

    void Start()
    {
        // プレハブをスクリプトのみで取得
        bullet = (GameObject)Resources.Load("Prefab/bulletPre");

        // 時間経過用変数を初期化
        time         = 0.0f;
        timeInterval = 0.3f;
    }

    // 更新を行うメソッド
    void Update ()
    {
        // 左右キーで回転させる
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -addDegree); // Y軸を基準に-addDegree度回転
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, addDegree); // Y軸を基準にaddDegree度回転
        }

        // 現在の向いてる方向を取得（ dir : direction(方向) ）
        Vector3 dir = transform.forward;

        // 初速度を与える
        float initialVelocity = 5.0f;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed = initialVelocity; // speedの値にaccel値を加算
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            speed = -initialVelocity; // speedの値にaccel値を減算
        }

        // 上下キーで前進後退(徐々に加速していく)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += accel; // speedの値にaccel値を加算
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            speed -= accel; // speedの値にaccel値を減算
        }
        else
        {
            if (speed < -0.01f)
            {
                speed += 0.02f;
            }
            else if (speed > 0.01f)
            {
                speed -= 0.02f;
            }
            else
            {
                speed = 0.0f;
            }
        }

        // 弾を発射
        if(Input.GetKey(KeyCode.Z))
        {
            if (timeInterval < time)
            {
                // 弾丸の複製
                //GameObject bullets = GameObject.Instantiate(bullet) as GameObject;
                GameObject.Instantiate(bullet);

                time = 0.0f;
            }

        }
        time += Time.deltaTime;

        // 方向＊移動量＊1フレームあたりにかかる時間を位置に加算　
        transform.position += dir * speed * Time.deltaTime;

    }
}
