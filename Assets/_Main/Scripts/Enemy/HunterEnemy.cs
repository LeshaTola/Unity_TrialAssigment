using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class HunterEnemy : Enemy, IDamageable
{
	[SerializeField] private float maxHealth;

	private Health health;
	private EnemyMovement movement;

	private void Awake()
	{
		movement = GetComponent<EnemyMovement>();
		health = new(maxHealth);
		health.OnDied += OnDied;
	}

	public void TakeDamage(float damage)
	{
		health.TakeDamage(damage);
	}

	private void OnDied()
	{
		Destroy(gameObject);
	}

}
