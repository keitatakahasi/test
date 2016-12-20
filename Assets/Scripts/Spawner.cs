using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	private const float spawnInterval = 3.0f;

	private float spawnTimer = 0.0f;
	private GameObject enemyPrefab;

	// 初期化処理
	private void Start()
	{
		enemyPrefab = (GameObject)Resources.Load("Prefab/EnemyPre");
		StartCoroutine("SpawnEnemy");
	}
	
	// 更新処理
	private void Update()
	{
	}

	IEnumerator SpawnEnemy()
	{
		for (;;)
		{
			// Object Generate Process
			Instantiate(enemyPrefab);

			// Pause Method 3 seconds.
			yield return new WaitForSeconds(spawnInterval);
		}
	}
}
