using TMPro;
using UnityEngine;

public class MainUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI timeText;
	[SerializeField] private GameManager gameManager;

	private void Start()
	{
		gameManager.Stopwatch.OnStopwatchUpdated += OnStopwatchUpdated;
		UpdateTimer(0, 0);
	}

	private void OnDestroy()
	{
		gameManager.Stopwatch.OnStopwatchUpdated -= OnStopwatchUpdated;
	}

	public void UpdateTimer(int minutes, int seconds)
	{
		timeText.text = $"{minutes}:{seconds}";
	}

	private void OnStopwatchUpdated(int minutes, int seconds)
	{
		UpdateTimer(minutes, seconds);
	}
}
