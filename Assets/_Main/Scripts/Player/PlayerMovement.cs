using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IControllable
{
	[SerializeField] private float speed;

	private Rigidbody2D RB;
	private Vector2 moveDir;

	private void Awake()
	{
		RB = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		MoveInternal();
	}

	public void Move(Vector2 direction)
	{
		moveDir = direction;
	}

	private void MoveInternal()
	{
		RB.velocity = moveDir * speed;
	}
}
