using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
	[SerializeField] private float speed;

	private Rigidbody2D rigidbody;
	private Transform target;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		Move();
	}

	public void Init(Transform target)
	{
		this.target = target;
	}

	private void Move()
	{
		Vector3 direction = Vector3.Normalize(target.position - transform.position);
		rigidbody.velocity = direction * speed;
	}
}
