using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private Enemy enemyTemplate;
	[SerializeField] private Player player;
	[SerializeField] private Collider2D spawnZone;
	[SerializeField] private Transform enemyContainer;
	[SerializeField] private float spawnRate = 0.5f;

	private float spawnRadius;
	private ObjectPool<Enemy> enemyPool;

	public ObjectPool<Enemy> EnemyPool { get => enemyPool; private set => enemyPool = value; }

	private void Start()
	{
		EnemyPool = new(
		() =>
		{
			var newEnemy = Instantiate(enemyTemplate, enemyContainer);
			newEnemy.Init(player, this);
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
		var spawnedEnemy = EnemyPool.Get();
		spawnedEnemy.transform.position = position;
	}

}
