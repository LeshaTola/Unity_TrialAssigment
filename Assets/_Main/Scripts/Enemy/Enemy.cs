using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] protected float damage;
	[SerializeField] protected float attackCooldown;

	protected bool isReadyToAttack = true;
	protected EnemySpawner spawner;
	protected Player player;

	public virtual void Init(Player player, EnemySpawner spawner)
	{
		this.player = player;
		this.spawner = spawner;
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Player player))
		{
			if (isReadyToAttack)
			{
				Attack(player);
				StartCooldown();
			}
		}
	}

	private void StartCooldown()
	{
		isReadyToAttack = false;
		Timer timer = new(targetTime: attackCooldown
			, endAction: () => { isReadyToAttack = true; });
		StartCoroutine(timer.Start());
	}

	protected void Attack(IDamageable player)
	{
		player.TakeDamage(damage);
	}
}
