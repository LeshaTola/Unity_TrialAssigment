public class MeleeWeapon : Weapon
{
	public override void Attack()
	{
		transform.position = owner.transform.position;
		gameObject.SetActive(true);

		Timer timer = new(targetTime: StatsSO.Duration,
			endAction: () => gameObject.SetActive(false));
		StartCoroutine(timer.Start());
	}
}
