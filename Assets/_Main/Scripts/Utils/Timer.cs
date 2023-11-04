public class Timer
{
	private Action<float> timerStepAction;
	private Action timerEndAction;

	public float CurrentTime { get; private set; }
	public float TargetTime { get; private set; }
	public float TimeStep { get; private set; }

	public Timer(float targetTime, float timeStep = 1f, Action<float> timerStepAction = null, Action timerEndAction = null)
	{
		TargetTime = targetTime;
		TimeStep = timeStep;
		this.timerStepAction = timerStepAction;
		this.timerEndAction = timerEndAction;
	}

	public IEnumerator StartTimer()
	{
		CurrentTime = 0;
		while (CurrentTime < TargetTime)
		{
			yield return new WaitForSeconds(TimeStep);
			CurrentTime += TimeStep;
			timerStepAction?.Invoke(TimeStep);
		}

		timerEndAction?.Invoke();
	}
}
