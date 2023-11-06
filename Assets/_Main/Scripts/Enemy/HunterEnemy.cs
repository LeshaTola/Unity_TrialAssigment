using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class HunterEnemy : Enemy, IDamageable
{
	[SerializeField] private float maxHealth;

	private Health health;
	private EnemyMovement movement;

	public override void Init(Player player, EnemySpawner spawner)
	{
		base.Init(player, spawner);
		movement = GetComponent<EnemyMovement>();
		movement.Init(player.transform);

		health = new(maxHealth);
		health.OnDied += OnDied;
	}

	private void OnDestroy()
	{
		health.OnDied -= OnDied;
	}

	public void TakeDamage(float damage)
	{
		health.TakeDamage(damage);
	}

	private void OnDied()
	{
		spawner.EnemyPool.Release(this);
		health.Heal(maxHealth);
	}

}
