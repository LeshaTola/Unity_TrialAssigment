using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class HunterEnemy : Enemy, IHealth, IDamageable
{
	[SerializeField] private float maxHealth;


	private EnemyMovement movement;

	public Health Health { get; private set; }

	public override void Init(Player player, EnemySpawner spawner)
	{
		base.Init(player, spawner);
		movement = GetComponent<EnemyMovement>();
		movement.Init(player.transform);

		Health = new(maxHealth);
		Health.OnDied += OnDied;
	}

	private void OnDestroy()
	{
		Health.OnDied -= OnDied;
	}

	public void TakeDamage(float damage)
	{
		Health.TakeDamage(damage);
	}

	private void OnDied()
	{
		spawner.EnemyPool.Release(this);
		Health.Heal(maxHealth);
	}

}
