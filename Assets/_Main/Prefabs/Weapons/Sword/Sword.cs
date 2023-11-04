using DG.Tweening;
using UnityEngine;

public class Sword : MeleeWeapon
{
	public override void Attack()
	{
		base.Attack();
		PlayAttackAnimation();//maybe move to Sword visual and triggers by event
	}

	private void PlayAttackAnimation()
	{
		int countOfAnimation = 3;
		float oneAnimationDuration = StatsSO.Duration / countOfAnimation;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(transform.DORotate(new Vector3(0f, 0f, 30), oneAnimationDuration));
		sequence.Append(transform.DORotate(new Vector3(0f, 0f, -30), oneAnimationDuration));
		sequence.Append(transform.DORotate(new Vector3(0f, 0f, 0), oneAnimationDuration));
		sequence.Play();
	}
}
