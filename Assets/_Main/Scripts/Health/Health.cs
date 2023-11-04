using System;
using UnityEngine;

[Serializable]
public class Health
{
	public event Action<float> OnValueChanged;
	public event Action OnDied;

	public float Value { get; private set; }
	[field: SerializeField] public float MaxValue { get; private set; }

	public Health(float maxValue)
	{
		MaxValue = maxValue;
	}

	public void TakeDamage(float damage)
	{
		if (damage < 0)
		{
			return;
		}

		Value -= damage;
		if (Value <= 0)
		{
			Value = 0;
			OnDied?.Invoke();
		}
		OnValueChanged?.Invoke(damage);
	}

	public void Heal(float healValue)
	{
		if (healValue < 0)
		{
			return;
		}

		Value += healValue;
		OnValueChanged?.Invoke(healValue);
	}
}
