using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour

{
	private PlayerAttack attackPoint;
	

	private Puntaje puntoExtra;

	public void AddDamage()
	{
		gameObject.SetActive(false);
		Debug.Log("TUVI333");
		if(attackPoint.bulletPlayer == true)
        {
			puntoExtra.OneP();

			attackPoint.bulletPlayer = false;

		}
	}
}
