using UnityEngine;

public class ProjectileWeapon : Weapon
{
	private Vector2 moveDirection;

	public override void Attack()
	{
		transform.position = owner.transform.position;
		moveDirection = owner.Movement.LastMoveDirection;
		gameObject.SetActive(true);

		Timer timer = new(targetTime: StatsSO.Duration,
			endAction: () => gameObject.SetActive(false));
		StartCoroutine(timer.Start());
	}

	private void FixedUpdate()
	{
		transform.position =
			Vector2.MoveTowards(transform.position, (Vector2)transform.position + moveDirection, Time.fixedDeltaTime * StatsSO.Speed);
	}

}
