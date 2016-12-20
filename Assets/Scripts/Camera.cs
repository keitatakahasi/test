using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{
    Vector3 offset = new Vector3(0.0f, 2.0f, -5.0f);

    void Start ()
    {


    }
	
	void Update ()
    {
        // シーンに配置されているゲームオブジェクト「Player」のtoransformを取得
        Transform playerTransform = GameObject.Find("Player").transform;

        // 弾の発射位置をプレーヤーの場所へ
        transform.position = playerTransform.position + offset;
    }
}
