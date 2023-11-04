using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Stats", menuName = "Weapon")]
public class WeaponStatsSO : ScriptableObject
{
	[field: SerializeField] public GameObject Prefab { get; private set; }
	[field: SerializeField] public float Damage { get; private set; }
	[field: SerializeField] public float Duration { get; private set; }
	[field: SerializeField] public float Speed { get; private set; }
	[field: SerializeField] public float Cooldown { get; private set; }

}
