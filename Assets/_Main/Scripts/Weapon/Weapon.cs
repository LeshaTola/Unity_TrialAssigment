using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
	[field: SerializeField] public WeaponStatsSO StatsSO { get; private set; }

	protected Player owner;

	public virtual void Init(Player owner)
	{
		this.owner = owner;
		gameObject.SetActive(false);
	}

	public abstract void Attack();
}
