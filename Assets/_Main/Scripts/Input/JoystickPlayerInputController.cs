using UnityEngine;

public class JoystickPlayerInputController : MonoBehaviour
{
	[SerializeField] private Joystick joystick;
	[SerializeField] private GameObject controllableGO;

	private IControllable controllable;

	private void Awake()
	{
		if (!controllableGO.TryGetComponent(out controllable))
		{
			Debug.LogError($"There is no script that implements IControllable on {controllableGO.name} GameObject");
		}
	}

	private void Update()
	{
		Vector2 inputDirection = new Vector2(joystick.Horizontal, joystick.Vertical);
		controllable.Move(inputDirection.normalized);
	}

}
