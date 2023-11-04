using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour, IDamageable
{
	[SerializeField] private List<WeaponStatsSO> weaponsSO;
	[SerializeField] private Health health;

	private List<Weapon> weapons = new();

	public PlayerMovement Movement { get; private set; }

	private void Awake()
	{
		Movement = GetComponent<PlayerMovement>();
		InitWeapons();
	}

	private void InitWeapons()
	{
		foreach (var weapon in weaponsSO)
		{
			var newWeaponGO = Instantiate(weapon.Prefab);
			var newWeapon = newWeaponGO.GetComponent<Weapon>();
			weapons.Add(newWeapon);

			if (newWeapon is MeleeWeapon)
				newWeapon.transform.SetParent(transform, false);

			newWeapon.Init(this);
			StartAttacking(newWeapon);
		}
	}

	public void StartAttacking(Weapon weapon)
	{
		Timer timer = new(weapon.StatsSO.Cooldown, looping: true, endAction: () => { weapon.Attack(); });
		StartCoroutine(timer.Start());
	}

	public void TakeDamage(float damage)
	{
		health.TakeDamage(damage);
	}
}
