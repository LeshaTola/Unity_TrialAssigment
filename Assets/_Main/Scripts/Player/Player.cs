using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private List<WeaponStatsSO> weaponsSO;

	[field: SerializeField] public PlayerMovement Movement { get; private set; }

	private List<Weapon> weapons = new();

	private void Awake()
	{
		foreach (var weapon in weaponsSO)
		{
			var newWeaponGO = Instantiate(weapon.Prefab);
			var newWeapon = newWeaponGO.GetComponent<Weapon>();
			weapons.Add(newWeapon);

			newWeapon.Init(this);
			StartAttacking(newWeapon);
		}
	}

	public void StartAttacking(Weapon weapon)
	{
		Timer timer = new(weapon.StatsSO.Cooldown, looping: true, endAction: () => { weapon.Attack(); });
		StartCoroutine(timer.Start());
	}
}
