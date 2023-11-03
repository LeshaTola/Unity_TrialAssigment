using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] private float speed;

	private Transform target;

	public void Init(Transform target)
	{
		this.target = target;
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
	}
}
