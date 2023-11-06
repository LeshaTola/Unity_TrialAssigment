using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
	[SerializeField] private Slider slider;
	[SerializeField] private GameObject gameObjectWithHealth;

	private IHealth iHealth;

	private void Start()
	{
		iHealth = gameObjectWithHealth.GetComponent<IHealth>();
		if (iHealth == null)
			Debug.LogError($"There is no component with IHealth on {gameObject.name}");

		iHealth.Health.OnValueChanged += OnHealthChanged;
	}

	private void OnDestroy()
	{
		iHealth.Health.OnValueChanged -= OnHealthChanged;
	}

	protected void OnHealthChanged(float health, float maxValue)
	{
		UpdateUI(health, maxValue);
	}

	public void UpdateUI(float health, float maxHealth)
	{
		slider.maxValue = maxHealth;
		slider.value = health;
	}
}
