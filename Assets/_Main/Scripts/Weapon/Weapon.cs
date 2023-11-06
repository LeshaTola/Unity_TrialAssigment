using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
	private const string LAYER_NAME = "Enemies";

	[field: SerializeField] public WeaponStatsSO StatsSO { get; private set; }

	protected Player owner;

	public virtual void Init(Player owner)
	{
		this.owner = owner;
		gameObject.SetActive(false);
	}

	public abstract void Attack();

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out IDamageable damageable))
		{
			if (collision.gameObject.layer == LayerMask.NameToLayer(LAYER_NAME))
			{
				damageable.TakeDamage(StatsSO.Damage);
			}
		}
	}
}
