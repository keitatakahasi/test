using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	
	private Vector3 moveDirection = new Vector3(0.0f, 0.0f, -5.0f);

	// 初期化処理
	private void Start()
	{
		// 自信の座標をX:-49~49 Y:0.5 Z:50 に移動
		Vector3 startPos = new Vector3(0.0f, 0.5f, 50.0f);
		float rnd = Random.Range(0.0f, 360.0f);

		startPos.z = Mathf.Sin(rnd * Mathf.Deg2Rad) * 50.0f;
		startPos.x = Mathf.Cos(rnd * Mathf.Deg2Rad) * 50.0f;
		transform.position = startPos;

		GetComponent<Renderer>().material.color = new Color(Random.Range(0,255), 0f,0f);
	}
	
	// 更新処理
	private void Update()
	{
		transform.position += moveDirection * Time.deltaTime;
	}
}
