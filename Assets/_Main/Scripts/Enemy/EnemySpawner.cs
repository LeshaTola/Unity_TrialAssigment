using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private Enemy enemyTemplate;
	[SerializeField] private PlayerMovement player;
	[SerializeField] private Collider2D spawnZone;

	private float spawnRadius;
	private ObjectPool<Enemy> enemyPool;

	private void Awake()
	{
		enemyPool = new(
			() => Instantiate(enemyTemplate),
			(obj) => obj.gameObject.SetActive(true),
			(obj) => obj.gameObject.SetActive(false), 10);
	}

	private void Start()
	{
		float offset = 1.5f;
		spawnRadius = Camera.main.orthographicSize * Camera.main.aspect * offset;
		StartCoroutine(SpawnTimer());
	}

	private IEnumerator SpawnTimer()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.5f);
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
