using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
	[SerializeField] private Slider slider;
	[SerializeField] private Player player;

	private void Start()
	{
		player.Health.OnValueChanged += OnHealthChanged;
	}

	private void OnDestroy()
	{
		player.Health.OnValueChanged -= OnHealthChanged;
	}

	private void OnHealthChanged(float health, float maxValue)
	{
		UpdateUI(health, maxValue);
	}

	public void UpdateUI(float health, float maxHealth)
	{
		slider.maxValue = maxHealth;
		slider.value = health;
	}
}
