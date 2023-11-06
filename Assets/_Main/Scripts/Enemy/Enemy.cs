using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] protected float damage;

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Player player))
		{
			Attack(player);
		}
	}

	protected void Attack(IDamageable player)
	{
		player.TakeDamage(damage);
	}
}
