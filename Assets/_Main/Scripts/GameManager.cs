using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Player player;
	[SerializeField] private int lastMinute;

	public Stopwatch Stopwatch { get; private set; }
	private Coroutine stopwatchCoroutine;

	private void Start()
	{
		Stopwatch = new Stopwatch(lastMinute);
		stopwatchCoroutine = StartCoroutine(Stopwatch.StartStopwatch());

		player.Health.OnDied += OnPlayerDied;
	}

	private void OnPlayerDied()
	{
		StopCoroutine(stopwatchCoroutine);
	}
}
