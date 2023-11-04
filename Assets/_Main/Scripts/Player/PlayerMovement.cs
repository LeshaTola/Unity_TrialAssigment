using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IControllable
{
	[SerializeField] private float speed;

	private Rigidbody2D rigidbody;
	public Vector2 MoveDirection { get; private set; }
	public Vector2 LastMoveDirection { get; private set; } = new Vector2(1, 0);

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		MoveInternal();
	}

	public void Move(Vector2 direction)
	{
		MoveDirection = direction;
		if (MoveDirection != LastMoveDirection && MoveDirection != Vector2.zero)
		{
			LastMoveDirection = MoveDirection;
		}
	}

	private void MoveInternal()
	{
		rigidbody.velocity = MoveDirection * speed;
	}
}
