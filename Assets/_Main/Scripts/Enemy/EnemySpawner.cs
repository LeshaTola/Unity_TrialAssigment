using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private EnemyMovement enemyTemplate;
	[SerializeField] private PlayerMovement player;
	[SerializeField] private Collider2D spawnZone;
	[SerializeField] private float spawnRate = 0.5f;

	private float spawnRadius;
	private ObjectPool<EnemyMovement> enemyPool;

	private void Start()
	{
		enemyPool = new(
		() =>
		{
			var newEnemy = Instantiate(enemyTemplate);
			newEnemy.Init(player.transform);
			return newEnemy;
		},
		(obj) => obj.gameObject.SetActive(true),
		(obj) => obj.gameObject.SetActive(false), 10);

		float offset = 1.5f;
		spawnRadius = Camera.main.orthographicSize * Camera.main.aspect * offset;
		StartCoroutine(SpawnTimer());
	}

	private IEnumerator SpawnTimer()
	{
		var timer = new WaitForSeconds(spawnRate);
		while (true)
		{
			yield return timer;
			Spawn();
		}
	}

	private void Spawn()
	{
		Vector2 spawnPosition;
		do
		{
			spawnPosition = Random.insideUnitCircle.normalized * spawnRadius + (Vector2)player.transform.position;
		}
		while (!spawnZone.bounds.Contains(spawnPosition));

		Spawn(spawnPosition);
	}

	private void Spawn(Vector2 position)
	{
		var spawnedEnemy = enemyPool.Get();
		spawnedEnemy.transform.position = position;
	}

}
