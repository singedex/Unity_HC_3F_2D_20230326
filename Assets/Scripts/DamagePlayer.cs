using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageSystem
{
	[Header("¦å±ø")]
	public Image imghp;

	public override void GetDamage(float damage)
	{
		base.GetDamage(damage);

		imghp.fillAmount = hp / hpMax;
	}
}
